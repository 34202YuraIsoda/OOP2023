using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.ConcreteConverter {
    static class ConverterFactory {
        // あらかじめインスタンスを生成し、配列に入れておく。
        private static Framework.ConverterBase[] _converters = new Framework.ConverterBase[] {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
            new KilometerConverter(),
            new MileConverter(),
        };

        public static Framework.ConverterBase GetInstance(string name) {
            return _converters.FirstOrDefault(x => x.IsMyUnit(name));
        }
    }
}
