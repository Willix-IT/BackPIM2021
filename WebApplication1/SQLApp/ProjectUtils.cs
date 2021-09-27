using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class ProjectUtils
    {
        private MySqlConnection connection;
        //constructeur
        public ProjectUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public Project getOne(int id)
        {
            Project result = new Project();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Project WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Site = (Site)sqlResult["Site"];
                result.Picture = (string)sqlResult["Picture"];
                result.Owner = (User)sqlResult["Owner"];
                result.Contributors = (User)sqlResult["Contributors"];
                result.IdArch = (int)sqlResult["Arch"];
            }

            this.connection.Close();

            return result;
        }

        public List<Project> getAll()
        {
            List<Project> values = new List<Project>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Project";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                Project result = new Project();
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Site = (Site)sqlResult["Site"];
                result.Picture = (string)sqlResult["Picture"];
                result.Owner = (User)sqlResult["Owner"];
                result.Contributors = (User)sqlResult["Contributors"];
                result.IdArch = (int)sqlResult["Arch"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.Project temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Project (Name, Site, Picture, Owner, Contributors, Arch) VALUES (@Name, @Site, @Picture, @Owner, @Contributors, @Arch)";

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Site", temp.Site);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Owner", temp.Owner);
            cmd.Parameters.AddWithValue("@Contributors", temp.Contributors);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.Project temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Project SET Name = @Name, Site = @Site, Picture = @Picture, Owner = @Owner, Contributors = @Contributors, Arch = @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Site", temp.Site);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Owner", temp.Owner);
            cmd.Parameters.AddWithValue("@Contributors", temp.Contributors);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Project WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
