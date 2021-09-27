using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class TravelHistoryUtils
    {
        private MySqlConnection connection;
        //constructeur
        public TravelHistoryUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }

        public TravelHistory getOne(int id)
        {
            TravelHistory result = new TravelHistory();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Travel_History WHERE Id=" + id.ToString();
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                result.Id = (int)sqlResult["Id"];
                result.Date = (DateTime)sqlResult["Date"];
                result.Object = (Storage)sqlResult["Object"];
                result.Start_Address = (string)sqlResult["Start_Address"];
                result.End_Address = (string)sqlResult["End_Address"];
                result.IdArch = (int)sqlResult["Arch"];

            }

            this.connection.Close();

            return result;
        }

        public List<TravelHistory> getAll()
        {
            List<TravelHistory> values = new List<TravelHistory>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM Travel_History";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                TravelHistory result = new TravelHistory();
                result.Id = (int)sqlResult["Id"];
                result.Date = (DateTime)sqlResult["Date"];
                result.Object = (Storage)sqlResult["Object"];
                result.Start_Address = (string)sqlResult["Start_Address"];
                result.End_Address = (string)sqlResult["End_Address"];
                result.IdArch = (int)sqlResult["Arch"];
                values.Add(result);
            }

            this.connection.Close();

            return values;
        }


        public void createOne(SQLModel.TravelHistory temp)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO Travel_History (Date, Object, Start_Address, End_Address, Arch) VALUES (@Date, @Object, @Start_Address, @End_Address, @Arch)";

            cmd.Parameters.AddWithValue("@Date", temp.Date);
            cmd.Parameters.AddWithValue("@Object", temp.Object);
            cmd.Parameters.AddWithValue("@Start_Address", temp.Start_Address);
            cmd.Parameters.AddWithValue("@End_Address", temp.End_Address);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void updateOne(SQLModel.TravelHistory temp, int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "UPDATE Travel_History SET Date = @Date, Object = @Object, Start_Address = @Start_Address, End_Address = @End_Address, Arch = @Arch WHERE Id=" + id.ToString();

            cmd.Parameters.AddWithValue("@Date", temp.Date);
            cmd.Parameters.AddWithValue("@Object", temp.Object);
            cmd.Parameters.AddWithValue("@Start_Address", temp.Start_Address);
            cmd.Parameters.AddWithValue("@End_Address", temp.End_Address);
            cmd.Parameters.AddWithValue("@Arch", temp.IdArch);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public void deleteOne(int id)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM Travel_History WHERE Id=" + id.ToString();

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
