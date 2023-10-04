using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            //IsMaech01();
            //IsMaech02();
            //StartWith();
            //EndWith();
            //PerfectMatch();
            PerfectMatch02();
        }

        //静的メソッドを使用した場合(@…逐語的リテラル)
        private static void IsMaech01() {
            var text = "private List<string> results = new List<string>();";
            bool isMatch = Regex.IsMatch(text,@"List<\w+>");
            if (isMatch) {
                Console.WriteLine("見つかりました");
            } else {
                Console.WriteLine("見つかりません");
            }
        }

        //インスタンスメソッドを使用した場合
        private static void IsMaech02() {
            var text = "private List<string> results = new List<string>();";
            var regex = new Regex(@"List<\w+>");
            bool isMatch = regex.IsMatch(text);
            if (isMatch) {
                Console.WriteLine("見つかりました");
            } else {
                Console.WriteLine("見つかりません");
            }
        }

        public static void StartWith() {
            var text = "using System.Text.RegularExpressions;";
            bool isMatch = Regex.IsMatch(text, @"^using");
            if (isMatch)
                Console.WriteLine("'using'で始まっています");
            else
                Console.WriteLine("'using'で始まっていません");
        }

        public static void EndWith() {
            var text = "Regexクラスを使った文字列操作について説明します。";
            bool isMatch = Regex.IsMatch(text, @"ます。$");
            if (isMatch)
                Console.WriteLine("'ます。'で終わっています");
            else
                Console.WriteLine("'ます。'で終わっていません");
        }

        //10-5
        public static void PerfectMatch() {
            var strings = new[] { "Microsoft Windows", "Windows Server", "Windows", };
            //var regex = new Regex(@"^(W|w)indows$");
            var regex = new Regex(@"(W|w)indows");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("{0}行と一致", count);
        }

        //10-7
        public static void PerfectMatch02() {
            var strings = new[] { "13000", "-50.6", "0.123",  "+180.00",
        "10.2.5", "320-0851", " 123", "$1200", "500円","1234-5678","123-456","1234-567" };
            //var regex = new Regex(@"^[-+]?(\d+)(\.\d+)?$");
            var regex = new Regex(@"^(\d{3})-(\d{4})$");
            foreach (var s in strings) {
                var isMatch = regex.IsMatch(s);
                if (isMatch)
                    Console.WriteLine(s);
            }
        }
    }
}
