using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class ArchUtils
    {
        private MySqlConnection connection;
        //constructeur
        public ArchUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public Arch getOne(int id)
        {
            Arch result = new Arch();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Arch WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Description = (string)sqlResult["Description"];
                result.MainAddress = (string)sqlResult["MainAddress"];
                result.PostalCode = (int)sqlResult["PostalCode"];
                result.City = (string)sqlResult["City"];
            }

            this.connection.Close();

            return result;
        }

        public List<Arch> getAll()
        {
            List<Arch> values = new List<Arch>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Arch";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                Arch result = new Arch();
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Description = (string)sqlResult["Description"];
                result.MainAddress = (string)sqlResult["MainAddress"];
                result.PostalCode = (int)sqlResult["PostalCode"];
                result.City = (string)sqlResult["City"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.Arch temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Arch (Name, Description, MainAddress, PostalCode, City) VALUES (@Name, @Description, @MainAddress, @PostalCode, @City)";

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Description", temp.Description);
            cmd.Parameters.AddWithValue("@MainAddress", temp.MainAddress);
            cmd.Parameters.AddWithValue("@PostalCode", temp.PostalCode);
            cmd.Parameters.AddWithValue("@City", temp.City);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.Arch temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Arch SET Name = @Name, Description = @Description, MainAddress = @MainAddress, PostalCode = @PostalCode, City = @City WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Description", temp.Description);
            cmd.Parameters.AddWithValue("@MainAddress", temp.MainAddress);
            cmd.Parameters.AddWithValue("@PostalCode", temp.PostalCode);
            cmd.Parameters.AddWithValue("@City", temp.City);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Arch WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
