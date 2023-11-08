using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double metricValue, imperialValue;


        public double MetricValue {
            get { return this.metricValue; }
            set {
                this.metricValue = value;
                this.OnPropertyChanged();
            }
        }

        public double ImperialValue {
            get { return this.imperialValue; }
            set {
                this.imperialValue = value;
                this.OnPropertyChanged();
            }
        }


        //上のComboBoxで選択されている値（単位）
        public MetricUnit CurrentMetricUnit { get; set; }

        //下のComboBoxで選択されている値（単位）
        public ImperialUnit CurrentImperialUnit { get; set; }

        //▲ボタンで呼ばれるコマンド
        public ICommand ImperialUnitToMetric { get; private set; }

        //▼ボタンで呼ばれるコマンド
        public ICommand MetricToImperialUnit { get; private set; }

        //コンストラクタ
        public MainWindowViewModel() {
            this.CurrentMetricUnit = MetricUnit.Units.First();
            this.CurrentImperialUnit = ImperialUnit.Units.First();

            this.MetricToImperialUnit = new DelegateCommand(
                () => this.ImperialValue = this.CurrentImperialUnit.FromMetricUnit(
                    this.CurrentMetricUnit, this.MetricValue));

            this.ImperialUnitToMetric = new DelegateCommand(
                () => this.MetricValue = this.CurrentMetricUnit.FromImperialUnit(
                    this.CurrentImperialUnit, this.ImperialValue));
        }
    }
}
