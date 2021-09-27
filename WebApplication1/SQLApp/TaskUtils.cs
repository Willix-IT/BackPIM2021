using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class TaskUtils
    {
        private MySqlConnection connection;
        //constructeur
        public TaskUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public Task getOne(int id)
        {
            Task result = new Task();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Task WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Project = (Project)sqlResult["Project"];
                result.Picture = (string)sqlResult["Picture"];
                result.IdArch = (int)sqlResult["Arch"];
            }

            this.connection.Close();

            return result;
        }

        public List<Task> getAll()
        {
            List<Task> values = new List<Task>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Task";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                Task result = new Task();
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Project = (Project)sqlResult["Project"];
                result.Picture = (string)sqlResult["Picture"];
                result.IdArch = (int)sqlResult["Arch"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.Task temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Task (Name, Project, Picture, Arch) VALUES (@Name, @Project, @Picture, @Arch)";

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Project", temp.Project);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.Task temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Task SET Name = @Name, Project = @Project, Picture = @Picture, Arch = @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Project", temp.Project);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Task WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
