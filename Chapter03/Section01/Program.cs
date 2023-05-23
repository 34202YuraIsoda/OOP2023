using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {

        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4, 25, 11, 94, 60, 12, 64, 75, 32, 48, 95, 24, 16, 35, 48 };

            //3以上8未満
            //int count = numbers.Count(n => n % 5 == 0 && n > 0);
            var sum = numbers.Where(n => n % 2 == 0).Average();


            Console.WriteLine(sum);

        }
    }
}
