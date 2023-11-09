using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //グラム単位を表すクラス
    public class GrammeUnit : DistanceUnit {
        private static List<GrammeUnit> units = new List<GrammeUnit>() {
            new GrammeUnit{Name = "g",Coefficient = 1,},
            new GrammeUnit{Name = "kg",Coefficient = 1000,},
        };
        public static ICollection<GrammeUnit> Units { get { return units; } }

        /// <summary>
        /// ヤード単位からメートル単位に変換します
        /// </summary>
        /// <param name="unit">ヤード単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>

        public double FromImperialUnit(ImperialUnit unit, double value) {
            return (value * unit.Coefficient) * 28.34952312500033 / this.Coefficient;
        }

    }
}
