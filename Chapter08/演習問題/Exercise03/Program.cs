using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var tw = new TimeWatch();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            Console.WriteLine("処理時間は{0}ミリ秒でした", duration.TotalMilliseconds);
        }
    }

    class TimeWatch {

        public DateTime dateTime { get; private set; }

        public void Start() {
            dateTime = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - dateTime;
        }

    }
}
