using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    class Program {
        static void Main(string[] args) {
            //インスタンスの生成
            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(235, "大福もち", 160);
            
            Console.WriteLine(karinto.Name + "(税込)：" + karinto.GetPriceIncludingTax());
            Console.WriteLine(daifuku.Name + "(税込)：" + daifuku.GetPriceIncludingTax());

        }
    }
}
