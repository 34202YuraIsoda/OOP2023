using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        private List<ItemData> itemDatas = new List<ItemData>();
        private List<ItemData> channelDatas = new List<ItemData>();
        private readonly List<string> radioButtomUrls = new List<string>()
        {"https://news.yahoo.co.jp/rss/topics/it.xml",          //  IT
         "https://news.yahoo.co.jp/rss/topics/sports.xml",      //  スポーツ
         "https://news.yahoo.co.jp/rss/topics/science.xml",     //  科学
         "https://news.yahoo.co.jp/rss/topics/world.xml",       //  国際
        };

        public Form1() {
            InitializeComponent();
            btDeleteFavorite.Enabled = false;
            lNumberOfRegistrations.Text = "0です";
        }

        //取得ボタンをクリックしたときの処理
        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                OpenReadUrlAndDisplay(wc, tbUrl.Text);
            }
        }

        //RssTitleリストボックスをクリックしたときの処理
        private void lbRssTitle_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex != -1) {// リストボックスの空白部分をクリックしたとき無視
                var d = itemDatas.First(x => x.Title.Equals(lbRssTitle.SelectedItem));
                wbBrowser.Navigate(d.Link);
            }
        }

        //タイトルをクリック時に上部テキストボックスにURLを挿入
        private void lbUrlTitle_Click(object sender, EventArgs e) {
            var n = channelDatas;
            if (lbUrlTitle.SelectedIndex != -1) {// リストボックスの空白部分をクリックしたとき無視
                foreach (var node in channelDatas) {
                    if (lbUrlTitle.Items[lbUrlTitle.SelectedIndex].ToString() == node.Title) {
                        tbUrl.Text = node.Link;
                        using (WebClient wc = new WebClient()) {
                            OpenReadUrlAndDisplay(wc, node.Link);
                            btDeleteFavorite.Enabled = true;
                        }
                    }
                }
            }
        }

        //URLの登録処理
        private void btRegister_Click(object sender, EventArgs e) {
            if (UrlCheck(tbUrl.Text)) {// URLが有効か無効かを判別
                using (var wc = new WebClient()) {
                    var url = wc.OpenRead(tbUrl.Text);
                    XDocument xdoc = XDocument.Load(url);
                    var titleName = xdoc.Root.Descendants("channel").Select(x => new ItemData {
                        Title = (string)x.Element("title"),
                        Link = tbUrl.Text
                    }).ToList().First().Title.ToString();
                    var rf = new RegistrationForm(titleName);
                    rf.ShowDialog();
                    var message = channelDatas.Where(c => c.Title == rf.UrlName).Count() == 0 ? rf.Message : "同じ名前は登録できません";
                    if (rf.ActiveControl.Text == "登録" || rf.ActiveControl.Text == "キャンセル") {// 登録もしくはキャンセルボタン以外は無視
                        if (channelDatas.Where(c => c.Title == rf.UrlName).Count() == 0 && rf.UrlName != "") {// 既に登録済みのタイトルと空白は無視
                            if (rf.ActiveControl.Text != "キャンセル") {// キャンセルボタンは無視
                                channelDatas.Add(new ItemData {
                                    Title = rf.UrlName,
                                    Link = tbUrl.Text
                                });
                                lbUrlTitle.Items.Add(channelDatas.Last().Title);
                            }
                        }
                        MessageBox.Show(message);
                    }
                }
            }
            lNumberOfRegistrationsUpdate();
        }

        //ラジオボタンを選択したときの処理
        private void CheckedChanged(object sender, EventArgs e) {
            var c = "";
            foreach (var item in gbRssTitle.Controls) {
                c = ((RadioButton)item).Checked ? radioButtomUrls[int.Parse((string)((RadioButton)item).Tag)] : c;
            }
            tbUrl.Text = c;
            using (var wc = new WebClient()) {
                OpenReadUrlAndDisplay(wc, c);
            }
        }

        //お気に入り削除
        private void btDeleteFavorite_Click(object sender, EventArgs e) {
            MessageBox.Show("「" + lbUrlTitle.Items[lbUrlTitle.SelectedIndex] + "」を削除しました");
            channelDatas.RemoveAt(lbUrlTitle.SelectedIndex);
            lbUrlTitle.Items.RemoveAt(lbUrlTitle.SelectedIndex);
            tbUrl.Text = "";
            lbRssTitle.Items.Clear();
            wbBrowser.Navigate("about:blank");
            btDeleteFavorite.Enabled = false;
            lNumberOfRegistrationsUpdate();
        }

        //URLを開き、内容を表示する
        private void OpenReadUrlAndDisplay(WebClient wc, string surl) {
            if (UrlCheck(surl)) {//URLが有効か無効か判別
                lbRssTitle.Items.Clear();
                var url = wc.OpenRead(surl);
                XDocument xdoc = XDocument.Load(url);
                itemDatas = xdoc.Root.Descendants("item").Select(x => new ItemData {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                }).ToList();
                foreach (var node in itemDatas) {
                    lbRssTitle.Items.Add(node.Title);
                }
                wbBrowser.Navigate("about:blank");
            }
        }

        private bool UrlCheck(string url) {
            try {
                using (WebClient wc = new WebClient()) {
                    wc.DownloadString(url);
                }
            } catch (Exception) {
                MessageBox.Show("URLが無効です");
                return false;
            }
            return true;
        }

        private void lNumberOfRegistrationsUpdate() {
            lNumberOfRegistrations.Text = channelDatas.Count().ToString() + "個です";
        }
    }
}
