using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise02 {
    public class Novelist {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string[] Masterpieces { get; set; }
    }
}
