using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();
        int mode = 0;

        //設定情報保存用オブジェクト
        Settings settings = new Settings();

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

        //車名をMakerGroupで返す
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

        //画像を開く
        private void btImageOpen_Click(object sender, EventArgs e) {
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
                btScaleChange.Enabled = true;   //画像削除ボタン有効
            }
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
            EditFieldReset();
        }

        //Form1を実行時の処理
        private void Form1_Load(object sender, EventArgs e) {
            currentTime.Start();
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            StatusLabelDisp();
            ModifyDeleteEnabled(false);

            try {
                //設定ファイルを逆シリアル化して背景を設定
                using (var reder = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    var settings = serializer.Deserialize(reder) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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

        //修正・削除ボタンのマスク可不可
        private void ModifyDeleteEnabled(bool enabled) {
            if (enabled) {
                btModifyReport.Enabled = true;  //修正ボタン有効
                btDeleteReport.Enabled = true;  //削除ボタン有効
                if (pbCarImage != null) {
                    btScaleChange.Enabled = true;   //画像削除ボタン有効
                }
            } else if (!enabled) {
                btDeleteReport.Enabled = false; //修正ボタン無効 
                btModifyReport.Enabled = false; //削除ボタン無効
                btScaleChange.Enabled = false;  //画像削除ボタン無効
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

        //画像削除ボタン
        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        //終了ボタン
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //バージョンフォームを開く
        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダルダイヤログとして表示
        }

        //色設定
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
            }
        }

        //現在時刻を表示する
        private void currentTime_Tick(object sender, EventArgs e) {
            tsTimeDisp.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:mm:ss");
        }

        //画像の大きさを変える
        private void btScaleChange_Click(object sender, EventArgs e) {
            mode++;
            if (mode > 4) {
                mode = 0;
            } else if (mode == 2) {
                mode = 3;
            }

            //pbCarImage.SizeMode = mode < PictureBoxSizeMode.Zoom ? ((mode == PictureBoxSizeMode.StretchImage) ? PictureBoxSizeMode.CenterImage : ++mode)) : PictureBoxSizeMode.Normal
            //mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0; //AutoSize(2)を除外
            //mode = %5; 別解

            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            settings.MainFormColor = BackColor.ToArgb();
            //設定ファイルのシリアル化
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e) {
            if (sfdCarRepoSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(sfdCarRepoSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, CarReports);
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e) {
            if (ofdCarRepoOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(ofdCarRepoOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        CarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;
                        foreach (var carReport in CarReports) {
                            SetCbAuthor(carReport.Author);
                            SetCbCarName(carReport.CarName);
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
