using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise03 {
    class ToHankakuProcessor :ITextFileService {

        private static Dictionary<char, char> _dictionary = new Dictionary<char, char>() {
            {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'},
            {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'}
        };

        public void Initialize(string fname) {
        }

        public void Execute(string line){
            var s = line;
            foreach (var num in _dictionary) {
                s = Regex.Replace(s,num.Key.ToString(),num.Value.ToString());
            }
            Console.WriteLine(s);
        }

        public void Terminate() {
        }
    }
}
