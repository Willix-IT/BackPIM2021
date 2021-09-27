using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Site Site { get; set; }
        public string Picture { get; set; }
        public User Owner { get; set; }
        public User Contributors { get; set; }
        public int IdArch { get; set; }
    }
}
