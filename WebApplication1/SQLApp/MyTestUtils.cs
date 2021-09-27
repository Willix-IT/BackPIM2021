using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using SQLModel;

namespace SQLApp
{
    public class MyTestUtils
    {
        private MySqlConnection connection;
        //constructeur
        public MyTestUtils()
        {
            SQLApp.SQLUtils SQLUtils = new SQLApp.SQLUtils();
            this.connection = SQLUtils.GetDBConnection();
        }
        public void addTest(SQLModel.TestModel test)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO test (nom, prenom, adresse, age) VALUES (@nom, @prenom, @adresse, @age)";

            cmd.Parameters.AddWithValue("@nom", test.nom);
            cmd.Parameters.AddWithValue("@prenom", test.prenom);
            cmd.Parameters.AddWithValue("@adresse", test.adresse);
            cmd.Parameters.AddWithValue("@age", test.age);

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }

        public List<TestModel> getAll()
        {
            List<TestModel> values = new List<TestModel>();

            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM test";
            MySqlDataReader sqlResult = cmd.ExecuteReader();

            while (sqlResult.Read())
            {
                TestModel t = new TestModel();
                t.nom = (string)sqlResult["nom"];
                t.prenom = (string)sqlResult["prenom"];
                t.adresse = (string)sqlResult["adresse"];
                t.age = (string)sqlResult["age"];
                values.Add(t);
            }

            this.connection.Close();

            return values;
        }
    }
}
