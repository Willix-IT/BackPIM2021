using System;
using System.Collections.Generic;
using System.Text;

namespace SQLModel
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Profil_Picture { get; set; }
        public string Role { get; set; }
    }
}
