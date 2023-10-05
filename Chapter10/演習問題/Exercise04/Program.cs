using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");
            var strs = new List<string>();
            foreach (var line in lines) {
                strs.Add(Regex.Replace(line, @"version\s*=\s*\""v\d\.\d\""", @"version=""v5.0""", RegexOptions.IgnoreCase));
            }
            File.WriteAllLines("sample.txt",strs);

            // これ以降は確認用
            Console.WriteLine();
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
