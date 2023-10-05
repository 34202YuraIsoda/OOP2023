using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var texts = new[] {
               "Time is money.",
               "What time is it?",
               "It will take time.",
               "We reorganized the timetable.",
            };
            foreach (var text in texts) {
                var strs = Regex.Matches(text, @"\btime\b", RegexOptions.IgnoreCase);
                foreach (Match str in strs) {
                    if (str.Success) {
                        Console.WriteLine("{0}:{1}", text, str.Index);
                    }
                }
            }



        }
    }
}
