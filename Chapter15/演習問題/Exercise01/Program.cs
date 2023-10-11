using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var books = Library.Books.Where(b => b.Price == Library.Books.Max(p => p.Price));
            Console.WriteLine("Exercise1_2");
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_3() {
            var books = Library.Books.GroupBy(b => b.PublishedYear);
            Console.WriteLine("Exercise1_3");
            foreach (var book in books.OrderBy(b => b.Key)) {
                Console.WriteLine("{0}年:{1}冊",book.Key,book.Count());
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books.GroupBy(b => b.PublishedYear).Select(g => g.OrderBy(b => b.PublishedYear).OrderByDescending(b => b.Price));
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_5() {

        }

        private static void Exercise1_6() {

        }

        private static void Exercise1_7() {

        }

        private static void Exercise1_8() {

        }
    }
}
