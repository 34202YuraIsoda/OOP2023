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
            Thread.Sleep(2525);
            TimeSpan duration = tw.Stop();
            Console.WriteLine("処理時間は{0}ミリ秒でした", duration.TotalMilliseconds);
        }
    }

    class TimeWatch {

        private DateTime _dateTime;

        public void Start() {
            _dateTime = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _dateTime;
        }

    }
}
