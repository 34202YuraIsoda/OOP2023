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
        int mode = 0;

        //設定情報保存用オブジェクト
        Settings settings = Settings.GetInstance();

        public Form1() {
            InitializeComponent();
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

            DataRow newRow = infosys202322DataSet.CarReportTable.NewRow();
            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = GetMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbCarImage.Image);

            infosys202322DataSet.CarReportTable.Rows.Add(newRow);
            this.carReportTableTableAdapter.Update(infosys202322DataSet.CarReportTable);

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
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentRow.Index);
            carReportTableTableAdapter.Update(infosys202322DataSet.CarReportTable);

            EditFieldReset();

        }

        //Form1を実行時の処理
        private void Form1_Load(object sender, EventArgs e) {
            currentTime.Start();
            dgvCarReports.Columns[0].Visible = false;   //ID項目非表示
            dgvCarReports.Columns[6].Visible = false;   //画像項目非表示
            StatusLabelDisp();
            ModifyDeleteEnabled(false);

            dgvCarReports.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReports.AlternatingRowsDefaultCellStyle.BackColor = Color.MistyRose;

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
        private void dgvCarReports_CellClick(object sender, DataGridViewCellEventArgs e) {
            ModifyDeleteEnabled(true);
            if (dgvCarReports.CurrentCell != null) {
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
                SetSelectedMaker(dgvCarReports.CurrentRow.Cells[3].Value.ToString());
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString();

                pbCarImage.Image = !dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)
                                        && ((Byte[])dgvCarReports.CurrentRow.Cells[6].Value).Length != 0 ?
                                    ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value) : null;

                //if (!dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)) {
                //    pbCarImage.Image = ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value);
                //} else {
                //    pbCarImage.Image = null;
                //}

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

        //修正ボタンイベントハンドラ
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;
                dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;
                dgvCarReports.CurrentRow.Cells[3].Value = GetMaker();
                dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text;
                dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;
                dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image;
                EditFieldReset();
                dgvCarReports.Refresh();    //一覧更新
            }

            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202322DataSet);

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

        //システム終了時（後）
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            settings.MainFormColor = BackColor.ToArgb();
            //設定ファイルのシリアル化
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202322DataSet);

        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void 接続CToolStripMenuItem_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202322DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202322DataSet.CarReportTable);

            foreach (var dscr in infosys202322DataSet.CarReportTable) {
                SetCbAuthor(dscr.Author);
                SetCbCarName(dscr.CarName);
            }

            EditFieldReset();
        }
    }
}