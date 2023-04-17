using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {

            //int count = int.Parse(Console.ReadLine());
            int count = 0;

            //①直角三角形
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //②逆直角三角形
            for (int i = 0; i < count; i++)
            {
                for (int j = count - (i + 1); j > 0; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //➂二等辺三角形
            for (int i = 0; i < count; i++)
            {
                for (int j = count - (i + 1); j > 0; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i * 2 + 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //④逆二等辺三角形
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = count * 2 - (i * 2 + 1); k > 0; k--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //⑤
            string[] moneyNames = {"一万円札","五千円札", "二千円札","千円札","五百円玉","百円玉","五十円玉",
                "十円玉","五円玉","一円玉",};
            int[] moneyStandard = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1 };
            int[] sheet = new int[moneyNames.Length];

            Console.Write("金額:");
            int amount = int.Parse(Console.ReadLine());
            Console.Write("支払:");
            int payment = int.Parse(Console.ReadLine());
            int change = payment - amount;
            Console.WriteLine("お釣:{0}円", change);

            totalMoney(sheet, moneyNames, ref change, moneyStandard);
            Console.WriteLine();
        }

        private static void totalMoney(int[] sheet, string[] moneyNames, ref int change, int[] moneyStandard) {
            for (int i = 0; i < moneyNames.Length; i++){
                sheet[i] = change / moneyStandard[i];
                change = change % moneyStandard[i];
                Console.WriteLine(moneyNames[i] + ":{0}枚", sheet[i]);
            }
            Console.WriteLine();
            for (int j = 0; j < moneyNames.Length; j++){
                Console.Write(moneyNames[j] + ":");
                astOut(sheet[j]);
            }
        }

        private static void astOut(int sheet) {
            for (int i = 0; i < sheet; i++){
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
