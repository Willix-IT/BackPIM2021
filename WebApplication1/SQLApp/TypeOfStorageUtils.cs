using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class TypeOfStorageUtils
    {
        private MySqlConnection connection;
        //constructeur
        public TypeOfStorageUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public TypeOfStorage getOne(int id)
        {
            TypeOfStorage result = new TypeOfStorage();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Type_Of_Storage WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Temperature = (decimal)sqlResult["Temperature"];
                result.Speciality = (string)sqlResult["Speciality"];
                result.Comment = (string)sqlResult["Comment"];
                result.IdArch = (int)sqlResult["Arch"];
            }

            this.connection.Close();

            return result;
        }

        public List<TypeOfStorage> getAll()
        {
            List<TypeOfStorage> values = new List<TypeOfStorage>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Type_Of_Storage";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                TypeOfStorage t = new TypeOfStorage();
                t.Id = (int)sqlResult["Id"];
                t.Name = (string)sqlResult["Name"];
                t.Temperature = (decimal)sqlResult["Temperature"];
                t.Speciality = (string)sqlResult["Speciality"];
                t.Comment = (string)sqlResult["Comment"];
                t.IdArch = (int)sqlResult["Arch"];
                values.Add(t);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.TypeOfStorage temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Type_Of_Storage (Name, Temperature, Speciality, Comment, Arch) VALUES (@Name, @Temperature, @Speciality, @Comment, @Arch)";

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Temperature", temp.Temperature);
            cmd.Parameters.AddWithValue("@Speciality", temp.Speciality);
            cmd.Parameters.AddWithValue("@Comment", temp.Comment);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.TypeOfStorage temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Type_Of_Storage SET Name = @Name, Temperature = @Temperature, Speciality = @Speciality, Comment = @Comment, Arch = @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Temperature", temp.Temperature);
            cmd.Parameters.AddWithValue("@Speciality", temp.Speciality);
            cmd.Parameters.AddWithValue("@Comment", temp.Comment);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Type_Of_Storage WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
