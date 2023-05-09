using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    class Program {
        static void Main(string[] args) {

            string[] DayOfWeekJp = { "日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日" };

            #region P26のサンプルプログラム
            //インスタンスの生成
            //Product karinto = new Product(123, "かりんとう", 180);
            //Product daifuku = new Product(235, "大福もち", 160);

            //Console.WriteLine(karinto.Name + "(税込)：" + karinto.GetPriceIncludingTax());
            //Console.WriteLine(daifuku.Name + "(税込)：" + daifuku.GetPriceIncludingTax());
            #endregion

            #region 0508演習1
            //DateTime date = new DateTime(2023, 5, 8);
            //DateTime date = DateTime.Today;
            //TimeSpan timeSpan = new TimeSpan(10, 0, 0, 0);

            //10日後を求める
            //DateTime daysAfter10 = date.AddDays(10);

            //10日前を求める
            //DateTime daysBefore10 = date.Subtract(timeSpan);

            //Console.WriteLine("今日の日付：" + date.Year + "年" + date.Month + "月" + date.Day + "日");
            //Console.WriteLine("10日後：" + daysAfter10.Year + "年" + daysAfter10.Month + "月" + daysAfter10.Day + "日");
            //Console.WriteLine("10日前：" + daysBefore10.Year + "年" + daysBefore10.Month + "月" + daysBefore10.Day + "日");
            #endregion

            #region 演習２
            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int day = int.Parse(Console.ReadLine());

            DateTime barthday = new DateTime(year, month, day);
            DateTime today = DateTime.Today;

            TimeSpan barthdayToToday = today - barthday;

            Console.WriteLine("あなたが生まれて今日で" + barthdayToToday.Days + "日目です。");
            #endregion

            Console.WriteLine(DayOfWeekJp[(int)barthday.DayOfWeek]);
        }
    }
}
