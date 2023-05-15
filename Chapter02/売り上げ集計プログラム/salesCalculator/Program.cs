using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salesCalculator {
    class Program {
        static void Main(string[] args) {

            SalesCounter sales = new SalesCounter(ReadSales(@"data\sales.csv"));
            Dictionary<string, int> amountPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string,int> obj in amountPerStore) {
                Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
            }

        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();//売り上げデータを格納する
            string[] lines = File.ReadAllLines(filePath);//ファイルからすべてのデータを読み込む

            foreach (string line in lines) {//すべての行から1行ずつ取り出す
                string[] items = line.Split(',');//区切りで項目別に分ける
                Sale sale = new Sale {//Saleインスタンスを生成
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale);//Saleインスタンスをコレクションに追加
            }

            return sales;
        }
    }
}
