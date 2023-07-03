using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var dateTime = new DateTime(2017, 01, 01);
            var today = DateTime.Today;

            foreach (var dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                Console.WriteLine("{0}の次週の{1}：{2}",dateTime.ToString("yy/MM/dd"),dayOfWeek,NextWeek(dateTime, (DayOfWeek)dayOfWeek).ToString("yyyy年MM月dd日(ddd)"));
            }

            Console.WriteLine();

            foreach (var dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                Console.WriteLine("{0}の次週の{1}：{2}", today.ToString("yy/MM/dd"), dayOfWeek, NextWeek(today, (DayOfWeek)dayOfWeek).ToString("yyyy年MM月dd日(ddd)"));
            }
        }

        public static DateTime NextWeek(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek) + 7;
            return date.AddDays(days);
        }
    }
}
