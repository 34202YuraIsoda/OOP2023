using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader {
    public partial class RegistrationForm : Form {

        public string UrlName { get; set; }
        public string Message { get; set; }

        public RegistrationForm(string titleName) {
            InitializeComponent();
            tbUrlName.Text = titleName;
            UrlName = titleName.Trim();
        }

        private void btRegistration_Click(object sender, EventArgs e) {
            UrlName = tbUrlName.Text.Trim();
            Message = UrlName == "" ? "空白は受け付けません" : "登録完了";
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e) {
            UrlName = "";
            Message = "登録中断";
            Close();
        }
    }
}
