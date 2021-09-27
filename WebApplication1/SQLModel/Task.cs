using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public Project Project { get; set; }
        public int IdArch { get; set; }

    }
}
