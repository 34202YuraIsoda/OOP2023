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

        }
    }
}
