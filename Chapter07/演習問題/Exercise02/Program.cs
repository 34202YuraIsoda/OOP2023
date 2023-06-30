using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            // コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            // Addメソッドの呼び出し
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            // 7.2.3
            Console.WriteLine("用語の数：{0}", abbrs.Count);
            if (abbrs.remove("IOC")) {
                Console.WriteLine("削除しました");
            }
            Console.WriteLine("用語の数：{0}", abbrs.Count);
            if (!abbrs.remove("IOC")) {
                Console.WriteLine("削除に失敗しました");
            }
            Console.WriteLine("用語の数：{0}", abbrs.Count);
            Console.WriteLine();

            // 7.2.4
            // IEumerable<> を実装したので、LINQが使える
            abbrs.Where(abb => abb.Key.Length == 3).ToList().ForEach(abb=> { Console.WriteLine("{0}={1}", abb.Key, abb.Value); });
        }
    }
}
