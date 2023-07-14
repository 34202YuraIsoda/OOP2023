using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }

        //ステータスラベルのテキスト表示・非表示（引数なしはメッセージ非表示）
        private void StatusLabelDisp(string mag = "") {
            tsInfoText.Text = mag;
        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            StatusLabelDisp();  //ステータスラベルのテキスト非表示
            if (cbAuthor.Text == "") {
                StatusLabelDisp("記録者を入力してください");
                return;
            } else if (cbCarName.Text == "") {
                StatusLabelDisp("車名を入力してください");
                return;
            }

            var CarReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image
            };

            CarReports.Add(CarReport);

            if (!cbAuthor.Items.Contains(cbAuthor.Text) && !cbCarName.Items.Contains(cbCarName.Text)) {
                cbAuthor.Items.Add(cbAuthor.Text);
                cbCarName.Items.Add(cbCarName.Text);
            }

            FieldReset();
            dgvCarReports.ClearSelection();
        }

        private void FieldReset() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = null;
            SetSelectedMaker("トヨタ");
            cbCarName.Text = null;
            tbReport.Text = null;
            pbCarImage.Image = null;
        }

        public CarReport.MakerGroup GetMaker() {
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Checked) {
                    return (CarReport.MakerGroup)int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return CarReport.MakerGroup.その他;
        }

        //指定したメーカーのラジオボタンをセット
        private void SetSelectedMaker(string makerName) {
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Text == makerName) {
                    ((RadioButton)item).Checked = true;
                    break;
                }
            }
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
            btDeleteReport.Enabled = false;
            btModifyReport.Enabled = false;
            FieldReset();
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            btModifyReport.Enabled = false; //マスクする
            btDeleteReport.Enabled = false;
        }

        //レコードの選択時
        private void dgvCarReports_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            btModifyReport.Enabled = true;
            btDeleteReport.Enabled = true;
            int serectedCurrentRowIndex = dgvCarReports.CurrentCell.RowIndex;
            dtpDate.Value = CarReports[serectedCurrentRowIndex].Date;
            cbAuthor.Text = CarReports[serectedCurrentRowIndex].Author;
            SetSelectedMaker(CarReports[serectedCurrentRowIndex].Maker.ToString());
            cbCarName.Text = CarReports[serectedCurrentRowIndex].CarName;
            tbReport.Text = CarReports[serectedCurrentRowIndex].Report;
            pbCarImage.Image = CarReports[serectedCurrentRowIndex].CarImage;
        }

        //更新ボタンイベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            int serectedCurrentRowIndex = dgvCarReports.CurrentCell.RowIndex;
            CarReports[serectedCurrentRowIndex].Date = dtpDate.Value;
            CarReports[serectedCurrentRowIndex].Author = cbAuthor.Text;
            CarReports[serectedCurrentRowIndex].Maker = GetMaker();
            CarReports[serectedCurrentRowIndex].CarName = cbCarName.Text;
            CarReports[serectedCurrentRowIndex].Report = tbReport.Text;
            CarReports[serectedCurrentRowIndex].CarImage = pbCarImage.Image;
            dgvCarReports.Refresh();    //一覧更新

        }

        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new Form2();
            vf.ShowDialog();    //モーダルダイヤログとして表示
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            cdColor.ShowDialog();
            BackColor = cdColor.Color;
        }
    }
}
