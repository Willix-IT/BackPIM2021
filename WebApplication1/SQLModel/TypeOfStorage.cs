using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class TypeOfStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Temperature { get; set; }
        public string Speciality { get; set; }
        public string Comment { get; set; }
        public int IdArch { get; set; }
    }
}
