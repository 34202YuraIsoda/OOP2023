using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Console.WriteLine("***** 3.1 *****");
            Exercise2_1(names);
            Console.WriteLine();
            Console.WriteLine("***** 3.2 *****");
            Exercise2_2(names);
            Console.WriteLine();
            Console.WriteLine("***** 3.3 *****");
            Exercise2_3(names);
            Console.WriteLine();
            Console.WriteLine("***** 3.4 *****");
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            do {
                Console.WriteLine("都市名を入力。空行で終了");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    break;
                }
                Console.WriteLine(names.FindIndex(n => line.Equals(n)));
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            Console.WriteLine(names.Count(n => n.Contains("o")));
        }

        private static void Exercise2_3(List<string> names) {
            var selection = names.Where(n => n.Contains("o")).ToArray();
            foreach (var n in selection) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var selection = names.Where(n => n.StartsWith("B")).Select(n =>new { n, n.Length });
            foreach (var n in selection) {
                Console.WriteLine(n);
            }
        }
    }
}
