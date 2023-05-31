using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            #region 5.1.1
#if false
            Console.Write("文字列：1");
            var str1 = Console.ReadLine();

            Console.Write("文字列：2");
            var str2 = Console.ReadLine();

            if (string.Compare(str1, str2, ignoreCase:true) == 0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
#endif
            #endregion

            #region 5.1.3
#if true
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            {\rtf1}
#endif
            #endregion

        }

        private static void Exercise3_1(string text) {
            text
        }

        private static void Exercise3_2(string text) {
        }

        private static void Exercise3_3(string text) {
        }

        private static void Exercise3_4(string text) {
        }

        private static void Exercise3_5(string text) {
        }
    }
}
