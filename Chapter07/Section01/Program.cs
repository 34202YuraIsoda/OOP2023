using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            string prefectureName, cityName;
            var cultureInfo = new CultureInfo("ja-JP");
            var prefectureDict = new Dictionary<string, string>();

            Console.WriteLine("県庁所在地の登録");
            Console.Write("県名：");
            prefectureName = Console.ReadLine();
            while (string.Compare(prefectureName, "999", cultureInfo, CompareOptions.IgnoreWidth) != 0) {
                Console.Write("所在地：");
                cityName = Console.ReadLine();
                if (prefectureDict.ContainsKey(prefectureName)) {
                    Console.WriteLine("{0}の県庁所在地は{1}として登録済みです。上書きしますか？ y/n", prefectureName, prefectureDict[prefectureName]);
                    if (string.Compare(Console.ReadLine(), "y", cultureInfo, CompareOptions.IgnoreWidth) == 0) {
                        prefectureDict[prefectureName] = cityName;//上書き
                    }
                } else {
                    prefectureDict[prefectureName] = cityName;//新規登録
                }
                Console.Write("県名：");
                prefectureName = Console.ReadLine();
            }

            Console.WriteLine("1：一覧表示,2：県名指定");
            switch (Console.ReadLine()) {

                case "1":
                    foreach (var prefecture in prefectureDict) {
                        Console.WriteLine("{0}({1})", prefecture.Key, prefecture.Value);
                    }
                    break;

                case "2":
                    Console.Write("県名を入力：");
                    var search = Console.ReadLine();
                    if (prefectureDict.ContainsKey(search)) {
                        Console.WriteLine("{0}({1})", search, prefectureDict[search]);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    class CityInfo {
        string City { get; set; }
        string Population { get; set; }
    }
}
