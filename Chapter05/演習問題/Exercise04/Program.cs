//#define NonArray
#define StringArray
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
#if true
            #region 自分
#if NonArray
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var novelists = new List<string>();
            var bestworks = new List<string>();
            var borns = new List<string>();
            var lines = line.Split('=', ';');
#elif StringArray
            string[] lines = {
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896"
            };
            var novelists = new List<string>();
            var bestworks = new List<string>();
            var borns = new List<string>();
            var sb = new StringBuilder();
            foreach(var item in lines){
                sb.Append(item);
                sb.Append(';');
            }
            var conectedLines = sb.ToString().Split('=', ';');

#endif
#if NonArray
            classificationPerson(lines, novelists, bestworks, borns);
            for (int i = 0; i < novelists.Count; i++) {
                Console.WriteLine("作家　：{0}", novelists[i]);
                Console.WriteLine("代表作：{0}", bestworks[i]);
                Console.WriteLine("誕生年：{0}", borns[i]);
            }
#elif StringArray
            classificationPerson(conectedLines, novelists, bestworks, borns);
            for (int i = 0; i < novelists.Count; i++) {
                Console.WriteLine("作家　：{0}", novelists[i]);
                Console.WriteLine("代表作：{0}", bestworks[i]);
                Console.WriteLine("誕生年：{0}", borns[i]);
            }

#endif
            #endregion
#endif
#if false
            #region 模範解答

#if NonArray

            var line = var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

#elif StringArray

            string[] lines = {
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896"
            };

#endif

#if NonArray

            foreach (var pair in line.Split(';')) {
                var array = pair.Split('=');
                Console.WriteLine("{0},{1}", ToJapanese(array[0], array[1]));
            }

#elif StringArray

            foreach (var line in lines) {
                foreach (var pair in line.Split(';')) {
                    var array = pair.Split('=');
                    Console.WriteLine("{0}：{1}", ToJapanese(array[0]), array[1]);
                }
            }

#endif

            #endregion
#endif
            Console.WriteLine("実行時間 = {0}", sw.Elapsed.ToString(@"ss\.fffff"));
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家　";
                case "BestWork":
                    return "代表作";
                case "Born":
                    return "誕生年";
            }
            throw new ArgumentException("正しい引数ではありません");
        }

        private static void classificationPerson(string[] lines, List<string> novelists, List<string> bestworks, List<string> borns) {
            int i = 0;
            foreach (var ob in lines) {
                if (ob == "Novelist") {
                    novelists.Add(lines[i + 1]);
                } else if (ob == "BestWork") {
                    bestworks.Add(lines[i + 1]);
                } else if (ob == "Born") {
                    borns.Add(lines[i + 1]);
                } else {
                    i++;
                    continue;
                }
                i++;
            }

        }
    }
}
