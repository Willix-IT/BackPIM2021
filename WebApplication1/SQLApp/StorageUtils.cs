using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class StorageUtils
    {
        private MySqlConnection connection;
        //constructeur
        public StorageUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public Storage getOne(int id)
        {
            Storage result = new Storage();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Storage WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Type_Of_Object = (string)sqlResult["Type_Of_Object"];
                result.State = (string)sqlResult["State"];
                result.Description = (string)sqlResult["Description"];
                result.Picture = (string)sqlResult["Picture"];
                result.Species = (Species)sqlResult["Species"];
                result.Site = (Site)sqlResult["Site"];
                result.IdArch = (int)sqlResult["Arch"];
            }

            this.connection.Close();

            return result;
        }

        public List<Storage> getAll()
        {
            List<Storage> values = new List<Storage>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Storage";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                Storage result = new Storage();
                result.Id = (int)sqlResult["Id"];
                result.Name = (string)sqlResult["Name"];
                result.Type_Of_Object = (string)sqlResult["Type_Of_Object"];
                result.State = (string)sqlResult["State"];
                result.Description = (string)sqlResult["Description"];
                result.Picture = (string)sqlResult["Picture"];
                result.Species = (Species)sqlResult["Species"];
                result.Site = (Site)sqlResult["Site"];
                result.IdArch = (int)sqlResult["Arch"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.Storage temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Storage (Name, Type_Of_Object, State, Description, Picture, Species, Site, Arch) VALUES (@Name, @Type_Of_Object, @State, @Description, @Picture, @Species, @Site, @Arch)";

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Type_Of_Object", temp.Type_Of_Object);
            cmd.Parameters.AddWithValue("@State", temp.State);
            cmd.Parameters.AddWithValue("@Description", temp.Description);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Species", temp.Species);
            cmd.Parameters.AddWithValue("@Site", temp.Site);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.Storage temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Storage SET Name = @Name, Type_Of_Object = @Type_Of_Object, State = @State, Description = @Description, Picture = @Picture, Species = @Species, Site = @Site, Arch= @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Name", temp.Name);
            cmd.Parameters.AddWithValue("@Type_Of_Object", temp.Type_Of_Object);
            cmd.Parameters.AddWithValue("@State", temp.State);
            cmd.Parameters.AddWithValue("@Description", temp.Description);
            cmd.Parameters.AddWithValue("@Picture", temp.Picture);
            cmd.Parameters.AddWithValue("@Species", temp.Species);
            cmd.Parameters.AddWithValue("@Site", temp.Site);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Storage WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
