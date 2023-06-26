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

                //模範解答
                //市町村情報インスタンスの生成
                //var cityInfo = new CityInfo {
                //    City = city,
                //    Population = population,
                //};

                //if(!prefectureDict.ContainsKey(prefectureName)){
                //    prefectureDict[prefectureName] = new List<CityInfo>();  //県名が未登録ならリスト作成

                //登録処理
                if (prefectureDict.ContainsKey(prefectureName)) {//List<CityInfo>が存在するためaddで市町村データを追加
                    prefectureDict[prefectureName].Add(new CityInfo {
                        City = cityName,
                        Population = population
                    });


                } else {//List<CityInfo>が存在しないため、Listを作成(new)して市町村データを登録
                    prefectureDict[prefectureName] = new List<CityInfo>();
                    prefectureDict[prefectureName].Add(new CityInfo {
                        City = cityName,
                        Population = population
                    });
                }


                Console.Write("県名：");
                prefectureName = Console.ReadLine();//県名の入力

            }

            if (prefectureDict.Count != 0) {//入力されているかいないか
                Console.WriteLine("1：一覧表示,2：県名指定");
                Console.Write(">");
                switch (Console.ReadLine()) {

                    case "1"://一覧表示
                        Console.WriteLine("1：入力順,2：各県の人口降順,3：各県の人口昇順");
                        Console.Write(">");

                        switch (Console.ReadLine()) {

                            case "1"://入力順
                                foreach (var prefecture in prefectureDict) {
                                    foreach (var item in prefecture.Value) {
                                        Console.WriteLine("{0}【 {1} (人口：{2:N0}人)】", prefecture.Key, item.City, item.Population);
                                    }
                                }
                                break;

                            case "2"://県ごとの人口降順
                                foreach (var prefecture in prefectureDict) {
                                    foreach (var item in prefecture.Value.OrderByDescending(p => p.Population)) {
                                        Console.WriteLine("{0}【 {1} (人口：{2:N0}人)】", prefecture.Key, item.City, item.Population);
                                    }
                                }
                                break;

                            case "3"://県ごとの人口昇順
                                foreach (var prefecture in prefectureDict) {
                                    foreach (var item in prefecture.Value.OrderBy(p => p.Population)) {
                                        Console.WriteLine("{0}【 {1} (人口：{2:N0}人)】", prefecture.Key, item.City, item.Population);
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                        break;


                    case "2"://県名指定表示
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
            } else {
                Console.WriteLine("入力されていないため表示せずに終了します");
            }
        }
    }

    class CityInfo {
        public string City { get; set; }//都市
        public int Population { get; set; }//人口
    }
}
