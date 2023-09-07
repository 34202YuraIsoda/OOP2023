using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise02 {
    [XmlRoot(ElementName = "novelist")]
    public class Novelist {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "birth")]
        public DateTime Birth { get; set; }
        [XmlArray("masterpieces")]
        [XmlArrayItem("title",typeof(string))]
        public string[] Masterpieces { get; set; }
    }
}
