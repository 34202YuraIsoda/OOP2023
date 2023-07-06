using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            var daySpan = DateTime.Now - dtp;

            tbMessage.Text = "入力日から" + daySpan.Days.ToString() + "日経過";
        }

        private void plusYear_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddYears(1);
            tbMessage.Text = dtpDate.Value.ToString("yyyy年MM月dd日(ddd)");
        }

        private void minusYear_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddYears(-1);
            tbMessage.Text = dtpDate.Value.ToString("yyyy年MM月dd日(ddd)");
        }

        private void plusMonth_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddMonths(1);
            tbMessage.Text = dtpDate.Value.ToString("yyyy年MM月dd日(ddd)");
        }

        private void minusMonth_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddMonths(-1);
            tbMessage.Text = dtpDate.Value.ToString("yyyy年MM月dd日(ddd)");
        }

        private void plusDay_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddDays(1);
            tbMessage.Text = dtpDate.Value.ToString("yyyy年MM月dd日(ddd)");
        }

        private void minusDay_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
            tbMessage.Text = dtpDate.Value.ToString("yyyy年MM月dd日(ddd)");
        }

        private void tbNowTime_TextChanged(object sender, EventArgs e) {

        }

        private void btAge_Click(object sender, EventArgs e) {
            int age = GetAge(dtpDate.Value, DateTime.Now);

            tbMessage.Text = "現在の年齢は" + age.ToString() + "歳";
        }

        public static int GetAge(DateTime birthday,DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if(targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        //タイマーイベントハンドラー
        private void tmTimeDisp_Tick(object sender, EventArgs e) {
            tbNowTime.Text = tbNowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日(dddd) HH時mm分ss秒");
        }

        private void Form1_Load(object sender, EventArgs e) {
            tbNowTime.Text = tbNowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日(dddd) HH時mm分ss秒");
            tmTimeDisp.Start();
        }
    }
}
