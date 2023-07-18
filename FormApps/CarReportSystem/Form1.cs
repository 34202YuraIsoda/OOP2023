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
        int mode = 0;

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

            SetCbAuthor(cbAuthor.Text);
            SetCbCarName(cbCarName.Text);

            EditFieldReset();
        }

        //記録者コンボボックスの履歴登録処理
        private void SetCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }
        }

        //車名コンボボックスの履歴登録処理
        private void SetCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        //項目クリア処理
        private void EditFieldReset() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = null;
            SetSelectedMaker("トヨタ");
            cbCarName.Text = null;
            tbReport.Text = null;
            pbCarImage.Image = null;

            ModifyDeleteEnabled(false);
            dgvCarReports.ClearSelection(); //選択解除
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
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
            }
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
            EditFieldReset();
        }

        private void Form1_Load(object sender, EventArgs e) {
            currentTime.Start();
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            StatusLabelDisp();
            ModifyDeleteEnabled(false);
        }

        //レコードの選択時
        private void dgvCarReports_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            ModifyDeleteEnabled(true);
            if (dgvCarReports.CurrentCell != null) {
                dtpDate.Value = CarReports[dgvCarReports.CurrentCell.RowIndex].Date;
                cbAuthor.Text = CarReports[dgvCarReports.CurrentCell.RowIndex].Author;
                SetSelectedMaker(CarReports[dgvCarReports.CurrentCell.RowIndex].Maker.ToString());
                cbCarName.Text = CarReports[dgvCarReports.CurrentCell.RowIndex].CarName;
                tbReport.Text = CarReports[dgvCarReports.CurrentCell.RowIndex].Report;
                pbCarImage.Image = CarReports[dgvCarReports.CurrentCell.RowIndex].CarImage;
            } else if (dgvCarReports.CurrentCell == null) {
                EditFieldReset();
            }
        }

        private void ModifyDeleteEnabled(bool enabled) {
            if (enabled) {
                btModifyReport.Enabled = true;  //修正ボタン有効
                btDeleteReport.Enabled = true;  //削除ボタン有効
            } else if (!enabled) {
                btDeleteReport.Enabled = false; //修正ボタン無効 
                btModifyReport.Enabled = false; //削除ボタン無効
            }
        }

        //更新ボタンイベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                CarReports[dgvCarReports.CurrentCell.RowIndex].Date = dtpDate.Value;
                CarReports[dgvCarReports.CurrentCell.RowIndex].Author = cbAuthor.Text;
                CarReports[dgvCarReports.CurrentCell.RowIndex].Maker = GetMaker();
                CarReports[dgvCarReports.CurrentCell.RowIndex].CarName = cbCarName.Text;
                CarReports[dgvCarReports.CurrentCell.RowIndex].Report = tbReport.Text;
                CarReports[dgvCarReports.CurrentCell.RowIndex].CarImage = pbCarImage.Image;
                EditFieldReset();
                dgvCarReports.Refresh();    //一覧更新
            }

        }

        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダルダイヤログとして表示
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
            }
        }

        private void currentTime_Tick(object sender, EventArgs e) {
            tsCurrentTimeText.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:ss");
        }

        private void btScaleChange_Click(object sender, EventArgs e) {
            mode++;
            if (mode > 4) {
                mode = 0;
            }

            //mode = mode < 4 ? ++mode : 0; 別解
            //mode = &5;

            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }
    }
}
