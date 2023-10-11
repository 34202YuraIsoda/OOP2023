using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            GroupBySample2();
            ToLookupSample();
        }

        //15-2
        public static void MaximumPrice() {
            var price = Library.Books.Where(b => b.CategoryId == 1).Max(b => b.Price);
            Console.WriteLine(price);
        }

        //15-3
        public static void MostShortTitleBook() {
            var min = Library.Books
                             .Min(x => x.Title.Length);
            var book = Library.Books
                              .First(b => b.Title.Length == min);
            Console.WriteLine(book);
        }

        public static void MostShortTitleBook2() {
            var book = Library.Books
                              .First(b => b.Title.Length ==
                                          Library.Books.Min(x => x.Title.Length));
            Console.WriteLine(book);
        }

        //15-8
        public static void GroupBySample() {
            var groups = Library.Books
                                .GroupBy(b => b.PublishedYear)
                                .OrderBy(g => g.Key);
            foreach (var g in groups) {
                Console.WriteLine($"{g.Key}年");
                foreach (var book in g) {
                    Console.WriteLine($"  {book}");
                }
            }
        }

        //List 15-9
        public static void GroupBySample2() {
            var selected = Library.Books
                                  .GroupBy(b => b.PublishedYear)
                                  .Select(group => group.OrderByDescending(b => b.Price)
                                                        .First())
                                  .OrderBy(o => o.PublishedYear);
            foreach (var book in selected) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Title} ({book.Price})");
            }
        }

        //List 15-10
        public static void ToLookupSample() {
            var lookup = Library.Books
                                .ToLookup(b => b.PublishedYear);
            var books = lookup[2014];
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }
    }
}
