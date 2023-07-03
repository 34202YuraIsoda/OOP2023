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
                Console.WriteLine(dateTime.ToString("yy/MM/ddの次週の") + dayOfWeek + "：" + NextDay(dateTime, (DayOfWeek)dayOfWeek).ToString("yyyy年MM月dd日(ddd)"));
            }

            Console.WriteLine();

            foreach (var dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                Console.WriteLine(today.ToString("yy/MM/ddの次週の") + dayOfWeek + "：" + NextDay(today,(DayOfWeek)dayOfWeek).ToString("yyyy年MM月dd日(ddd)"));
            }
        }

        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek) + 7;
            return date.AddDays(days);
        }
    }
}
