using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {

            var sales = new SalesCounter(@"data\sales.csv");
            Console.WriteLine("**売上集計**");
            Console.WriteLine("1:店舗別売り上げ");
            Console.WriteLine("2:商品カテゴリー別売り上げ");
            Console.Write(">");
            int selection = int.Parse(Console.ReadLine());
            switch (selection) {
                case 1:
                    var amountPerStore = sales.GetPerStoreSales();
                    foreach (var obj in amountPerStore) {
                        Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                    }
                    break;
                case 2:
                    var amountPerProductCategory = sales.GetPerProductCategorySales();
                    foreach (var obj in amountPerProductCategory) {
                        Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                    }
                    break;
                default:
                    Console.WriteLine("入力値が不正です。");
                    break;
            }
        }
    }
}
