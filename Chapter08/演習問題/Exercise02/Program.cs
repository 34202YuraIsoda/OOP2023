using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            DateTime dateTime = DateTime.Today;

            foreach (var dayOfWeek in Enum.GetValues(typeof(DayOfWeek))) {
                Console.WriteLine(NextDay(dateTime,(DayOfWeek)dayOfWeek).ToString("yyyy年MM月dd日(dddd)"));
            }
        }

        public static DateTime NextDay(DateTime date, DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek) + 7;
            return date.AddDays(days);
        }
    }
}
