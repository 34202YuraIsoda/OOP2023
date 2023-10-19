using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.ConcreteConverter {
    public class YardConverter : Framework.ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "yard" || name == UnitName;
        }
        protected override double Ratio { get { return 0.9144; } }
        public override string UnitName { get { return "ヤード"; } }
    }
}
