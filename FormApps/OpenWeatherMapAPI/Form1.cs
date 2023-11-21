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

namespace OpenWeatherMapAPI {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            using (WebClient wc = new WebClient()) {
                var key = wc.OpenRead("https://www.weatherapi.com/confirm.aspx?code=cb22afce-ff74-4499-a464-0dc9c2d6dd51");
                textBox1.Text =  key.Position.ToString();
            }
        }
    }
}
