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
        private static Database _instance;
        private string connectionString = "server=localhost;user=root;database=education_db;port=3306;password=codegym;";

        // constructor private to another object cannot initialization
        private Database()
        {

        }
        //property
        public static Database Instance
        {
            get
            {
                // check if there is any instance
                if (_instance == null)
                {
                    //not (first call), create new
                    _instance = new Database();
                }
                // if have, return 
                return _instance;
            }
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
