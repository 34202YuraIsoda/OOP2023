using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace {

    class Replace {}

    static class ToReplace {
        public static string ToFull(string single) {
            var sb = new StringBuilder();
            foreach (var c in single) {
                switch (c) {
                    case '０':
                        sb.Append('0');
                        break;
                    case '１':
                        sb.Append('1');
                        break;
                    case '２':
                        sb.Append('2');
                        break;
                    case '３':
                        sb.Append('3');
                        break;
                    case '４':
                        sb.Append('4');
                        break;
                    case '５':
                        sb.Append('5');
                        break;
                    case '６':
                        sb.Append('6');
                        break;
                    case '７':
                        sb.Append('7');
                        break;
                    case '８':
                        sb.Append('8');
                        break;
                    case '９':
                        sb.Append('9');
                        break;
                    default:
                        break;
                }
            }
            string full = sb.ToString();
            return full;
        }

        public static string ToSingle(string full) {
            var sb = new StringBuilder();
            foreach (var c in full) {
                switch (c) {
                    case '0':
                        sb.Append('０');
                        break;
                    case '1':
                        sb.Append('１');
                        break;
                    case '2':
                        sb.Append('２');
                        break;
                    case '3':
                        sb.Append('３');
                        break;
                    case '4':
                        sb.Append('４');
                        break;
                    case '5':
                        sb.Append('５');
                        break;
                    case '6':
                        sb.Append('６');
                        break;
                    case '7':
                        sb.Append('７');
                        break;
                    case '8':
                        sb.Append('８');
                        break;
                    case '9':
                        sb.Append('９');
                        break;
                    default:
                        break;
                }
            }
            string single = sb.ToString();
            return single;
        }
    }
}
