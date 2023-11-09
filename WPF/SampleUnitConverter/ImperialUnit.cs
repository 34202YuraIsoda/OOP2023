using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //ポンド単位を表すクラス
    public class ImperialUnit : DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit>() {
            new ImperialUnit{Name = "oz",Coefficient = 1,},
            new ImperialUnit{Name = "lb",Coefficient = 16,},
            new ImperialUnit{Name = "stone",Coefficient = 16 * 14,},
        };
        public static ICollection<ImperialUnit> Units { get { return units; } }

        /// <summary>
        /// メートル単位からヤード単位に変換します
        /// </summary>
        /// <param name="unit">メートル単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>

        public double FromMetricUnit(GrammeUnit unit, double value) {
            return (value * unit.Coefficient) / 28.34952312500033 / this.Coefficient;
        }
    }
}
