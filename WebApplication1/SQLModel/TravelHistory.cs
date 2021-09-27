using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class TravelHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Storage Object { get; set; }
        public string Start_Address { get; set; }
        public string End_Address { get; set; }
        public int IdArch { get; set; }

    }
}
