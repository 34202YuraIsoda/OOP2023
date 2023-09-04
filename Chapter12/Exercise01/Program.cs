using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string v) {
            var employee = new Employee {
                Id = 1,
                Name = "a",
                HireDate = DateTime.Parse("2000/01/01"),
            };

            using (var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }
        }

        private static void Exercise1_2(string v) {
            var employees = new Employee[]{
                new Employee {
                    Id = 1,
                    Name = "a",
                    HireDate = DateTime.Parse("2000/01/01"),
                },
                new Employee {
                    Id = 2,
                    Name = "b",
                    HireDate = DateTime.Parse("2020/12/31"),
                },
                new Employee {
                    Id = 3,
                    Name = "c",
                    HireDate = DateTime.Parse("2023/11/01"),
                }
            };

            var settings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };
            using (var writer = XmlWriter.Create(v)) {
                var serializer = new DataContractSerializer(employees.GetType());
                serializer.WriteObject(writer, employees);
            }
        }

        private static void Exercise1_3(string v) {
            using (var reader = XmlReader.Create(v)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var employees = serializer.ReadObject(reader) as Employee[];
                foreach (var employee in employees) {
                    Console.WriteLine("Id＝{0} ,Name＝{1} ,HireDate＝{2}", employee.Id, employee.Name, employee.HireDate);
                }
            }

        }

        private static void Exercise1_4(string v) {
            var employees = new Employee[]{
                new Employee {
                    Id = 1,
                    Name = "a",
                    HireDate = DateTime.Parse("2000/01/01"),
                },
                new Employee {
                    Id = 2,
                    Name = "b",
                    HireDate = DateTime.Parse("2020/12/31"),
                },
                new Employee {
                    Id = 3,
                    Name = "c",
                    HireDate = DateTime.Parse("2023/11/01"),
                }
            };

            using (var stream = new FileStream(v, FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(employees.GetType());
                serializer.WriteObject(stream, employees);
            }

        }
    }
}
