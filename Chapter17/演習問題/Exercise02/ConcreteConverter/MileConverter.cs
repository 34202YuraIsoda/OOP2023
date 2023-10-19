using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.ConcreteConverter {
    public class MileConverter : Framework.ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "mile" || name == UnitName;
        }
        protected override double Ratio { get { return 1609.344; } }
        public override string UnitName { get { return "マイル"; } }
    }
}
