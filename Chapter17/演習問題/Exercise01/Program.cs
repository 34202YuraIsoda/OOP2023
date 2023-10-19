using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            TextProcessor.Run<ToHankakuProcessor>(@"C:\Users\infosys\source\repos\OOP2023\Chapter17\演習問題\Exercise01\bin\Debug\Sample.txt");
        }
    }
}
