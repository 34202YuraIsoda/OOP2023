using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollarChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        PropertyInfo[] colors = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static);
        List<StockColor> stocks = new List<StockColor>();

        public class MyColor {
            public Color Color { get; set; }
            public string Name { get; set; }
        }

        public class StockColor {
            public string colorRed { get; set; }
            public string colorGreen { get; set; }
            public string colorBlue { get; set; }

            public override string ToString() {
                return "R:" + colorRed + " G:" + colorGreen + " B:" + colorBlue ;
            }
        }

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
            colorArea.Background = new SolidColorBrush(Color.FromRgb(byte.Parse(rValue.Text), byte.Parse(gValue.Text), byte.Parse(bValue.Text)));
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            colorArea.Background = new SolidColorBrush(Color.FromRgb(byte.Parse(rSlider.Value.ToString()), byte.Parse(gSlider.Value.ToString()), byte.Parse(bSlider.Value.ToString())));
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var i = stockList.SelectedIndex;
            rSlider.Value = double.Parse(stocks[i].colorRed);
            gSlider.Value = double.Parse(stocks[i].colorGreen);
            bSlider.Value = double.Parse(stocks[i].colorBlue);
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var colorList = GetColorList();
            StockColor stock = new StockColor {
                colorRed = rValue.Text,
                colorGreen = gValue.Text,
                colorBlue = bValue.Text
            };
            Color color = Color.FromRgb(byte.Parse(stock.colorRed), byte.Parse(stock.colorGreen), byte.Parse(stock.colorBlue));
            string s = MyColorChecker(stock.colorRed,stock.colorGreen,stock.colorBlue) ?
                colorList.Where(c => c.Color == color).FirstOrDefault().Name : stock.ToString();
            stockList.Items.Add(s);
            stocks.Add(stock);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var n = (MyColor)((ComboBox)sender).SelectedItem;
            rSlider.Value = double.Parse(n.Color.R.ToString());
            gSlider.Value = double.Parse(n.Color.G.ToString());
            bSlider.Value = double.Parse(n.Color.B.ToString());
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private Boolean MyColorChecker(string r,string g,string b) {
            Boolean match = false;
            Color color = Color.FromRgb(byte.Parse(r),byte.Parse(g),byte.Parse(b));
            foreach (var item in colors) {
                var n = (Color)item.GetValue(item);
                match = color == n || match;
            }
            return match;
        }
    }
}
