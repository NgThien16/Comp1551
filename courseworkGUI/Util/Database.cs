using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace courseworkGUI
{
    internal class Database
    {
        public static string connectionString = "server=localhost;user=root;database=education_db;port=3306;password=codegym;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);

        }
        public static MySqlConnection GetOpenConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
