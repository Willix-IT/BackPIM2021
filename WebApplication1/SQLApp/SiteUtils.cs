using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class SiteUtils
    {
        private MySqlConnection connection;
        //constructeur
        public SiteUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public Site getOne(int id)
        {
            Site result = new Site();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Site WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Address = (string)sqlResult["Address"];
                result.Manager = (User)sqlResult["Manager"];
                result.City = (string)sqlResult["City"];
                result.Country = (string)sqlResult["Country"];
                result.Type_Of_Storage = (TypeOfStorage)sqlResult["Type_Of_Storage"];
                result.IdArch = (int)sqlResult["Arch"];
            }

            this.connection.Close();

            return result;
        }

        public List<Site> getAll()
        {
            List<Site> values = new List<Site>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Site";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                Site result = new Site();
                result.Id = (int)sqlResult["Id"];
                result.Address = (string)sqlResult["Address"];
                result.Manager = (User)sqlResult["Manager"];
                result.City = (string)sqlResult["City"];
                result.Country = (string)sqlResult["Country"];
                result.Type_Of_Storage = (TypeOfStorage)sqlResult["Type_Of_Storage"];
                result.IdArch = (int)sqlResult["Arch"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.Site temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Site (Address, Manager, City, Country, Type_Of_Storage, Arch) VALUES (@Address, @Manager, @City, @Country, @Type_Of_Storage, @Arch)";

            cmd.Parameters.AddWithValue("@Address", temp.Address);
            cmd.Parameters.AddWithValue("@Manager", temp.Manager);
            cmd.Parameters.AddWithValue("@City", temp.City);
            cmd.Parameters.AddWithValue("@Country", temp.Country);
            cmd.Parameters.AddWithValue("@Type_Of_Storage", temp.Type_Of_Storage);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.Site temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Site SET Address = @Address, Manager = @Manager, City = @City, Country = @Country, Type_Of_Storage = @Type_Of_Storage, Arch = @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Address", temp.Address);
            cmd.Parameters.AddWithValue("@Manager", temp.Manager);
            cmd.Parameters.AddWithValue("@City", temp.City);
            cmd.Parameters.AddWithValue("@Country", temp.Country);
            cmd.Parameters.AddWithValue("@Type_Of_Storage", temp.Type_Of_Storage);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Site WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
