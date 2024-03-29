﻿using System;
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
            Console.WriteLine("//Exercise1_2");
            var books = Library.Books.Where(b => b.Price == Library.Books.Max(p => p.Price));
            foreach (var book in books) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_3() {
            Console.WriteLine("//Exercise1_3");
            var books = Library.Books.GroupBy(b => b.PublishedYear);
            foreach (var book in books.OrderBy(b => b.Key)) {
                Console.WriteLine("{0}年 {1}冊", book.Key, book.Count());
            }
        }

        private static void Exercise1_4() {
            Console.WriteLine("//Exercise1_4");
            var groupBooks = Library.Books.GroupBy(b => b.PublishedYear).OrderByDescending(g => g.Key);
            foreach (var books in groupBooks) {
                foreach (var book in books.OrderByDescending(b => b.Price)) {
                    Console.WriteLine("{0}年 {1}円 {2} ({3})",
                        book.PublishedYear, book.Price, book.Title,Library.Categories.Where(c => c.Id == book.CategoryId).First().Name);
                }
            }
        }

        private static void Exercise1_5() {
            Console.WriteLine("//Exercise1_5");
            var publishedYear2016OfCategories = Library.Books.Where(b => b.PublishedYear == 2016)
                                                             .Join(Library.Categories,
                                                                    b => b.CategoryId,
                                                                    c => c.Id,
                                                                    (b, c) => c.Name)
                                                             .Distinct();
            foreach (var categorie in publishedYear2016OfCategories) {
                Console.WriteLine(categorie);
            }
        }

        private static void Exercise1_6() {
            Console.WriteLine("//Exercise1_6");
            var query = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    book.PublishedYear,
                    book.Price,
                    book.Title,
                    categoryName = category.Name,
                })
                .GroupBy(x => x.categoryName)
                .OrderBy(x => x.Key);
            foreach (var group in query) {
                Console.WriteLine("#{0}", group.Key);
                foreach (var item in group) {
                    Console.WriteLine(" {0}", item.Title);
                }
            }
        }

        private static void Exercise1_7() {
            Console.WriteLine("//Exercise1_7");
            var catid = Library.Categories.Single(c => c.Name == "Development").Id;
            var groups = Library.Books
                                .Where(b => b.CategoryId == catid)
                                .GroupBy(b => b.PublishedYear)
                                .OrderBy(b => b.Key);
            foreach (var group in groups) {
                Console.WriteLine("#{0}年", group.Key);
                foreach (var item in group) {
                    Console.WriteLine("{0}", item.Title);
                }
            }
        }

        private static void Exercise1_8() {
            var query = Library.Categories
                                .GroupJoin(
                                    Library.Books,
                                    c => c.Id,
                                    b => b.CategoryId,
                                    (c, b) => new {
                                        CategoryName = c.Name,
                                        Count = b.Count()
                                    })
                                .Where(x => x.Count >= 4);
            foreach (var category in query) {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}
