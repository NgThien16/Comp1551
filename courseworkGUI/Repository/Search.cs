using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace courseworkGUI
{
    internal class Search
    {
        public static DataTable SearchUsers(string keyword)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE name LIKE @keyword";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
