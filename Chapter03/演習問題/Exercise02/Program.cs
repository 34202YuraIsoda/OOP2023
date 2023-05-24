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
                var city = Console.ReadLine();
                if (string.IsNullOrEmpty(city)) {
                    break;
                }
                Console.WriteLine(names.FindIndex(n => city.Equals(n)));
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            Console.WriteLine(names.Count(n => n.ToString().Contains("o")));
        }

        private static void Exercise2_3(List<string> names) {
            foreach (var n in names.Where(n => n.ToString().Contains("o"))) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise2_4(List<string> names) {
            foreach(var n in names.Where(n => n[0] == 'B').Select(n => n)) {
                Console.WriteLine("{0},{1}", n, n.Length);
            }
        }
    }
}
