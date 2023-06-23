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
            string prefectureName, cityName, yORn;
            int population;
            var cultureInfo = new CultureInfo("ja-JP");
            var prefectureDict = new Dictionary<string, CityInfo>();

            Console.WriteLine("県庁所在地の登録");

            Console.Write("県名：");
            prefectureName = Console.ReadLine();//県名の入力

            while (string.Compare(prefectureName, "999", cultureInfo, CompareOptions.IgnoreWidth) != 0) {

                Console.Write("所在地：");
                cityName = Console.ReadLine();//所在地の入力

                if (prefectureDict.ContainsKey(prefectureName)) {
                    Console.Write("{0}の所在地は{1}として登録済みです。上書きしますか？ (y/n)：", prefectureName, prefectureDict[prefectureName].City);
                    while (true) {
                        yORn = Console.ReadLine();
                        if (string.Compare(yORn, "y", cultureInfo, CompareOptions.IgnoreWidth) == 0) {
                            prefectureDict[prefectureName].City = cityName;//上書き
                            Console.WriteLine("上書きしました");
                            break;
                        } else if (string.Compare(yORn, "n", cultureInfo, CompareOptions.IgnoreWidth) == 0) {
                            Console.WriteLine("キャンセルしました");//キャンセル
                            break;
                        } else {
                            Console.WriteLine("既定の文字以外が入力されました。再入力してください。");//yとn以外が入力されたとき
                            continue;
                        }
                    }
                }

                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());//人口の入力

                //登録処理
                prefectureDict[prefectureName] = new CityInfo {
                    City = cityName,
                    Population = population
                };

                Console.Write("県名：");
                prefectureName = Console.ReadLine();//県名の入力

            }

            Console.WriteLine("1：一覧表示,2：県名指定");
            Console.Write(">");
            switch (Console.ReadLine()) {

                case "1":
                    if (prefectureDict.Count != 0) {
                        var prefectureDictDesc = prefectureDict.OrderByDescending(p=>p.Value.Population);
                        foreach (var prefecture in prefectureDictDesc) {
                            Console.WriteLine("{0}【 {1} (人口：{2:N0}人)】", prefecture.Key, prefecture.Value.City, prefecture.Value.Population);
                        }
                    }
                    break;

                case "2":
                    Console.Write("県名を入力：");
                    var search = Console.ReadLine();
                    if (prefectureDict.ContainsKey(search)) {
                        Console.WriteLine("{0}【 {1} ( 人口：{2:N0}人)】", search, prefectureDict[search].City, prefectureDict[search].Population);
                    }
                    break;

                default:
                    break;
            }
        }
    }

    class CityInfo {
        public string City { get; set; }//都市
        public int Population { get; set; }//人口
    }
}
