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

        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            //https://news.yahoo.co.jp/rss/topics/it.xml
            if (tbUrl.Text.Contains("xml")) {
                using (var wc = new WebClient()) {
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
            if (lbRssTitle.SelectedIndex != -1) {
                var d = itemDatas.First(x => x.Title.Equals(lbRssTitle.SelectedItem));
                wbBrowser.Navigate(d.Link);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbUrl.Text);
                XDocument xdoc = XDocument.Load(url);
                var channelDatas = xdoc.Root.Descendants("channel").Select(x => new ItemData {
                    Title = (string)x.Element("title"),
                    Link = (string)x.Element("link")
                }).ToList();
                foreach (var node in channelDatas) {
                    listBox1.Items.Add(node.Title);
                }
            }
            if (!listBox1.Items.Contains(tbUrl.Text) && tbUrl.Text.Trim() != "") {
                listBox1.Items.Add(tbUrl.Text);
            }
        }

        private void listBox1_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex != -1) {
                tbUrl.Text = (string)listBox1.Items[listBox1.SelectedIndex];
            }
        }
    }
}
