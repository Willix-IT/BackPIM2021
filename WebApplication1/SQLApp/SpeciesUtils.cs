using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class SpeciesUtils
    {
        private MySqlConnection connection;
        //constructeur
        public SpeciesUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public Species getOne(int id)
        {
            Species result = new Species();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Species WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Type = (string)sqlResult["Type"];
                result.Picture = (string)sqlResult["Picture"];
                result.IdArch = (int)sqlResult["Arch"];
            }

            this.connection.Close();

            return result;
        }

        public List<Species> getAll()
        {
            List<Species> values = new List<Species>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Species";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                Species result = new Species();
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Type = (string)sqlResult["Type"];
                result.Picture = (string)sqlResult["Picture"];
                result.IdArch = (int)sqlResult["Arch"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.Species temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Species (Name, Type, Picture, Arch) VALUES (@Name, @Type, @Picture, @Arch)";

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Type", temp.Type);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.Species temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Species SET Name = @Name, Type = @Type, Picture = @Picture, Arch = @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Type", temp.Type);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Species WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
