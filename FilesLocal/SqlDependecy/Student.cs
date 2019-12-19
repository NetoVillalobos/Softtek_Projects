using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SqlDependecy
{
    public class Student
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
