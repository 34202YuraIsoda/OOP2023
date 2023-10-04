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
        List<ItemData> itemDatas = new List<ItemData>();
        List<ItemData> channelDatas = new List<ItemData>();

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            //https://news.yahoo.co.jp/rss/topics/it.xml
            //https://news.yahoo.co.jp/rss/topics/science.xml
            //https://news.yahoo.co.jp/rss/topics/sports.xml
            using (var wc = new WebClient()) {
                var uri = new Uri(tbUrl.Text);
                var n = uri();
                lbRssTitle.Items.Clear();
                if (false) {// 正規のurlでなければ無視
                    var url = wc.OpenRead(tbUrl.Text);
                    XDocument xdoc = XDocument.Load(url);
                    itemDatas = xdoc.Root.Descendants("item").Select(x => new ItemData {
                        Title = (string)x.Element("title"),
                        Link = (string)x.Element("link")
                    }).ToList();
                    foreach (var node in itemDatas) {
                        lbRssTitle.Items.Add(node.Title);
                    }
                }
            }
        }

        private void lbRssTitle_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex != -1) {// リストボックスの空白部分をクリックしたとき無視
                var d = itemDatas.First(x => x.Title.Equals(lbRssTitle.SelectedItem));
                wbBrowser.Navigate(d.Link);
            }
        }

        // タイトルをクリック時に上部テキストボックスにURLを挿入
        private void lbUrlTitle_Click(object sender, EventArgs e) {
            var n = channelDatas;
            if (lbUrlTitle.SelectedIndex != -1) {// リストボックスの空白部分をクリックしたとき無視
                foreach (var node in channelDatas) {
                    if (lbUrlTitle.Items[lbUrlTitle.SelectedIndex].ToString() == node.Title) {
                        tbUrl.Text = node.Link;
                    }
                }
            }
        }

        // URLの登録処理
        private void btRegister_Click(object sender, EventArgs e) {
            if (tbUrl.Text.Contains("xml")) {// xml形式でなければ無視
                using (var wc = new WebClient()) {
                    var url = wc.OpenRead(tbUrl.Text);
                    XDocument xdoc = XDocument.Load(url);
                    itemDatas = xdoc.Root.Descendants("channel").Select(x => new ItemData {
                        Title = (string)x.Element("title"),
                        Link = tbUrl.Text
                    }).ToList();
                    foreach (var node in itemDatas) {
                        node.Title.Trim();// 空白除去
                        if (!lbUrlTitle.Items.Contains(node.Title)) {// 既に登録済みのタイトルは無視
                            channelDatas.Add(new ItemData {
                                Title = node.Title,
                                Link = tbUrl.Text
                            });
                            lbUrlTitle.Items.Add(node.Title);
                        }
                    }
                }
            }
        }
    }
}
