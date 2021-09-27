using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class Site
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public User Manager { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public TypeOfStorage Type_Of_Storage { get; set; }
        public int IdArch { get; set; }

    }
}
