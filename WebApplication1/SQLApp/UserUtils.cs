using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class UserUtils
    {
        private MySqlConnection connection;
        //constructeur
        public UserUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public User getOne(int id)
        {
            User result = new User();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM User WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.First_Name = (string)sqlResult["First_Name"];
                result.Last_Name = (string)sqlResult["Last_Name"];
                result.Birth_Date = (DateTime)sqlResult["Birth_Date"];
                result.Email = (string)sqlResult["Email"];
                result.Password = (string)sqlResult["Password"];
                result.Phone = (string)sqlResult["Phone"];
                result.Profil_Picture = (string)sqlResult["Profil_Picture"];
                result.Role = (string)sqlResult["Role"];
            }

            this.connection.Close();

            return result;
        }

        public List<User> getAll()
        {
            List<User> values = new List<User>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM User";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                User result = new User();
                result.Id = (int)sqlResult["Id"];
                result.First_Name = (string)sqlResult["First_Name"];
                result.Last_Name = (string)sqlResult["Last_Name"];
                result.Birth_Date = (DateTime)sqlResult["Birth_Date"];
                result.Email = (string)sqlResult["Email"];
                result.Password = (string)sqlResult["Password"];
                result.Phone = (string)sqlResult["Phone"];
                result.Profil_Picture = (string)sqlResult["Profil_Picture"];
                result.Role = (string)sqlResult["Role"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.User temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO User (First_Name, Last_Name, Birth_Date, Email, Password, Phone, Profil_Picture, Role) VALUES (@First_Name, @Last_Name, @Birth_Date, @Email, @Password, @Phone, @Profil_Picture, @Role)";

            cmd.Parameters.AddWithValue("@First_Name", temp.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", temp.Last_Name);
            cmd.Parameters.AddWithValue("@Birth_Date", temp.Birth_Date);
            cmd.Parameters.AddWithValue("@Email", temp.Email);
            cmd.Parameters.AddWithValue("@Password", temp.Password);
            cmd.Parameters.AddWithValue("@Phone", temp.Phone);
            cmd.Parameters.AddWithValue("@Profil_Picture", temp.Profil_Picture);
            cmd.Parameters.AddWithValue("@Role", temp.Role);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.User temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE User SET First_Name = @First_Name, Last_Name = @Last_Name, Birth_Date = @Birth_Date, Email = @Email, Password = @Password, Phone = @Phone, Profil_Picture = @Profil_Picture, Role = @Role WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@First_Name", temp.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", temp.Last_Name);
            cmd.Parameters.AddWithValue("@Birth_Date", temp.Birth_Date);
            cmd.Parameters.AddWithValue("@Email", temp.Email);
            cmd.Parameters.AddWithValue("@Password", temp.Password);
            cmd.Parameters.AddWithValue("@Phone", temp.Phone);
            cmd.Parameters.AddWithValue("@Profil_Picture", temp.Profil_Picture);
            cmd.Parameters.AddWithValue("@Role", temp.Role);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM User WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
