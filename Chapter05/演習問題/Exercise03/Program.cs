using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            #region 5.1.3
#if true
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            //{\rtf1}
#endif
            #endregion

        }

        private static void Exercise3_1(string text) {
            var count = text.Count(n => n.ToString().Contains(' '));
            Console.WriteLine("空白：{0}", count);
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var texts = text.Split(' ');
            Console.WriteLine(texts.Length);
        }

        private static void Exercise3_4(string text) {
            var texts = text.Split(' ').ToList();
            texts.FindAll(s => s.Length <= 4).ForEach(n => Console.WriteLine(n));
        }

        private static void Exercise3_5(string text) {
            var sb = new StringBuilder();
            var texts = text.Split(' ');
            foreach (var target in texts) {
                sb.Append(target);
                sb.Append(' ');
            }
            var connectionText = sb.ToString();
            Console.WriteLine(connectionText);
        }

    }
}

