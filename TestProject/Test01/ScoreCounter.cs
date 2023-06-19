using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： 生徒のデータを読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var students = new List<Student>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines) {
                var obj = line.Split(',');
                var student = new Student() {
                    Name = obj[0],
                    Subject = obj[1],
                    Score = int.Parse(obj[2])
                };
                students.Add(student);
            }

            return students;
            
        }

        //メソッドの概要： 科目別の合計点数を求める
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var score in _score) {
                if (dict.ContainsKey(score.Subject))
                    dict[score.Subject] += score.Score;  //科目名が既に存在する(点数加算)
                else
                    dict[score.Subject] = score.Score;  //科目名が存在しない(新規格納)
            }
            return dict;
        }
    }
}
