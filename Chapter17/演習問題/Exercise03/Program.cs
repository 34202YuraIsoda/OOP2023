﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = new TextFileProcessor(new ToHankakuProcessor());
            text.Run("Sample.txt");
        }
    }
}
