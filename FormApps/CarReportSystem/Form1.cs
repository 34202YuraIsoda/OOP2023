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

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            var CarReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image
            };
            CarReports.Add(CarReport);
            btModifyReport.Enabled = true;
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
            if (CarReports.Count != 0) {
                CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            btModifyReport.Enabled = false; //マスクする
        }

        //レコードの選択時
        private void dgvCarReports_CellContentClick(object sender, DataGridViewCellEventArgs e) {
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
            dgvCarReports.Refresh();

        }
    }
}
