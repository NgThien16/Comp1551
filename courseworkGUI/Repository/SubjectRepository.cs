using courseworkGUI.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Repository
{
    internal class SubjectRepository
    {
        public List<Subject> GetAll()
        {
            List<Subject> list = new List<Subject>();
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                // Lấy tất cả môn học
                string sql = "SELECT * FROM subjects";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new Subject(
                                Convert.ToInt32(rdr["subject_id"]),
                                rdr["subject_code"].ToString(),
                                rdr["name"].ToString(),
                                Convert.ToInt32(rdr["credit"])
                            ));
                        }
                    }
                }
            }
            return list;
        }
    }
}
