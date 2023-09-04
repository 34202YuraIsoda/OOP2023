using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    [DataContract(Name = "employee")]
    public class Employee {
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "hiredate")]
        public DateTime HireDate { get; set; }
    }
}
