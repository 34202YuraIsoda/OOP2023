using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise05 {
    class Program {
        static void Main(string[] args) {
            TagLower("sample.html");
        }

        private static void TagLower(string file) {
            var lines = File.ReadLines(file);
            var sb = new StringBuilder();
            foreach (var line in lines) {
                var matches = Regex.Matches(line, @"<.+[^<>]>\b");
                foreach (Match match in matches) {
                    Console.WriteLine(match);
                }
            }







            //ファイル出力
            //File.WriteAllText(file, sb.ToString());
        }
    }
}
