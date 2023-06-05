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
            var count = text.Count(c => c.ToString().Contains(' '));
            Console.WriteLine("空白：{0}", count);

            //var count = text.Count(c => c == ' ');模範解答
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            var texts = text.Split(' ');
            Console.WriteLine("単語数：{0}", texts.Length);

            //int count = text.Split(' ').Length;模範解答
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').ToList();
            words.FindAll(s => s.Length <= 4).ForEach(s => Console.WriteLine(s));

            //var words = text.Split(' ').Where(word => word.Length <= 4);模範解答
            //foreach (var word in words) {
            //    Console.WriteLine(word);
            //}
        }

        private static void Exercise3_5(string text) {
            var sb = new StringBuilder();
            var words = text.Split(' ');
            foreach (var word in words) {
                sb.Append(word);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            var connectedText = sb.ToString();
            Console.WriteLine(connectedText);

            //var array = text.Split(' ').ToArray();
            //var sb = new StringBuilder(array[0]);
            //foreach (var word in array.Skip(1)) {
            //sb.Append(' ');
            //sb.Append(word);
            //}
            //var createWords = sb.ToString();
            //Console.WriteLine(createWords);模範解答
        }

    }
}

