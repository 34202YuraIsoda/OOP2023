using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            string prefectureName, cityName;
            int population;
            var cultureInfo = new CultureInfo("ja-JP");
            var prefectureDict = new Dictionary<string, List<CityInfo>>();

            Console.WriteLine("都市の登録");

            Console.Write("県名：");
            prefectureName = Console.ReadLine();//県名の入力

            while (string.Compare(prefectureName, "999", cultureInfo, CompareOptions.IgnoreWidth) != 0) {

                Console.Write("都市：");
                cityName = Console.ReadLine();//都市の入力

                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());//人口の入力

                //登録処理
                if (prefectureDict.ContainsKey(prefectureName)) {
                    prefectureDict[prefectureName].Add(new CityInfo {
                        City = cityName,
                        Population = population
                    });
                } else {
                    prefectureDict[prefectureName] = new List<CityInfo>();
                    prefectureDict[prefectureName].Add(new CityInfo {
                        City = cityName,
                        Population = population
                    });
                }

                Console.Write("県名：");
                prefectureName = Console.ReadLine();//県名の入力

            }

            Console.WriteLine("1：一覧表示,2：県名指定");
            Console.Write(">");
            switch (Console.ReadLine()) {

                case "1":
                    if (prefectureDict.Count != 0) {
                        foreach (var prefecture in prefectureDict) {
                            foreach (var item in prefecture.Value) {
                                Console.WriteLine("{0}【 {1} (人口：{2:N0}人)】", prefecture.Key, item.City, item.Population);
                            }
                        }
                    }
                    break;

                case "2":
                    Console.Write("県名を入力：");
                    var search = Console.ReadLine();
                    if (prefectureDict.ContainsKey(search)) {
                        foreach (var item in prefectureDict[search]) {
                            Console.WriteLine("{0}【 {1} ( 人口：{2:N0}人)】", search, item.City, item.Population);
                        }
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
