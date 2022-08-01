using Calculator.Model;
using Calculator.Viewmodel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class DBManager
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=calculator;";
        
        public static ObservableCollection<DataBaseModel> Query()
        {
            var dbViewmodel= new ObservableCollection<DataBaseModel>();
            // Your query,
            string query = "SELECT * FROM calculator";
            MySqlConnection conn = new MySqlConnection(connectionString);
            //这是连接语句
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //逐步读取数据库中的数据，然后添加到集合中
                dbViewmodel.Add(new DataBaseModel()
                {
                    ID = reader.GetInt32("ID"),
                    Infix = reader.GetString("Infix"),
                    Prefix = reader.GetString("Prefix"),
                    Postfix = reader.GetString("Postfix"),
                    Decimal = reader.GetString("Dec"),
                    Binary = reader.GetString("Bin")
                });
            }
            conn.Close();
            return dbViewmodel;
        }
        public static bool Insert(DataBaseModel data)
        {
            // Your query,
            string query = $"SELECT * FROM calculator WHERE Infix = {data.Infix}";
            MySqlConnection conn = new MySqlConnection(connectionString);
            //这是连接语句
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                conn.Open();
                query = $"INSERT INTO calculator (`Infix`, `Prefix`, `Postfix`, `Dec`, `Bin`) VALUES ('{data.Infix}', '{data.Prefix}', '{data.Postfix}', '{data.Decimal}', '{data.Binary}');";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteReader();
                conn.Close();
                return true;
            }           
            
        }
        public static void Delete(DataBaseModel data)
        {
            // Your query,
            string query = $"DELETE FROM calculator WHERE ID = {data.ID}";
            MySqlConnection conn = new MySqlConnection(connectionString);
            //这是连接语句
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();            

        }
    }
}
