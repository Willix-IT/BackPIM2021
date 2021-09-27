using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class Arch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainAddress { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
    }
}
