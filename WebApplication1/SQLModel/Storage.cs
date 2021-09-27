using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type_Of_Object { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Species Species { get; set; }
        public Site Site { get; set; }
        public int IdArch { get; set; }
    }
}
