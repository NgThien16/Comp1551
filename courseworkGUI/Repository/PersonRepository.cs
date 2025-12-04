using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace courseworkGUI.Repository
{
    internal class PersonRepository
    {
        public List<Person> GetAll()
        {
            List<Person> listPerson = new List<Person>();
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT u.*, s.name AS subject_name 
                       FROM users u
                       LEFT JOIN subjects s ON u.subject_id = s.subject_id
                       ORDER BY u.role";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string id = rdr["id"].ToString();
                            string name = rdr["name"].ToString();
                            string phone = rdr["phone"].ToString();
                            string email = rdr["email"] != DBNull.Value ? rdr["email"].ToString() : "";
                            string role = rdr["role"].ToString();

                          
                            if (role == "Teacher")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                int subId = rdr["subject_id"] != DBNull.Value ? Convert.ToInt32(rdr["subject_id"]) : 0;

                                string subName = rdr["subject_name"] != DBNull.Value ? rdr["subject_name"].ToString() : "";
                                listPerson.Add(new Teacher(id,name,phone,email,sal, subId, subName));
                            }
                            else if (role == "Student")
                            {
                                int subId = rdr["subject_id"] != DBNull.Value ? Convert.ToInt32(rdr["subject_id"]) : 0;
                                string subName = rdr["subject_name"] != DBNull.Value ? rdr["subject_name"].ToString() : "";

                                listPerson.Add(new Student(id, name, phone, email, subId, subName));
                            }
                            else if (role == "Admin")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                bool full = rdr["is_full_time"] != DBNull.Value ? Convert.ToBoolean(rdr["is_full_time"]) : false;
                                int hrs = rdr["working_hours"] != DBNull.Value ? Convert.ToInt32(rdr["working_hours"]) : 0;
                                listPerson.Add(new Admin(id, name, phone, email, sal, full, hrs));
                            }
                        }
                    }
                }
            }
            return listPerson;
        }
        public List<Person> SearchUsers(string keyword)
        {
            List<Person> listPerson = new List<Person>();

            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();

                // search by name or phone
                string sql = @"SELECT u.*, s.name AS subject_name 
                       FROM users u
                       LEFT JOIN subjects s ON u.subject_id = s.subject_id
                       WHERE (u.name LIKE @kw OR u.phone LIKE @kw) 
                       ORDER BY u.role";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    // add % at end and start to search string(Contains)
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {

                            string id = rdr["id"].ToString();
                            string name = rdr["name"].ToString();
                            string phone = rdr["phone"].ToString();
                            string email = rdr["email"] != DBNull.Value ? rdr["email"].ToString() : "";
                            string role = rdr["role"].ToString();

                            Person person = null;

                            if (role == "Teacher")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                int subId = rdr["subject_id"] != DBNull.Value ? Convert.ToInt32(rdr["subject_id"]) : 0;
                                string subName = rdr["subject_name"] != DBNull.Value ? rdr["subject_name"].ToString() : "";
                                person = new Teacher(id, name, phone, email, sal, subId, subName);
                            }
                            else if (role == "Student")
                            {
                                int subId = rdr["subject_id"] != DBNull.Value ? Convert.ToInt32(rdr["subject_id"]) : 0;
                                string subName = rdr["subject_name"] != DBNull.Value ? rdr["subject_name"].ToString() : "";
                                person = new Student(id, name, phone, email, subId, subName);
                            }
                            else if (role == "Admin")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                bool full = rdr["is_full_time"] != DBNull.Value ? Convert.ToBoolean(rdr["is_full_time"]) : false;
                                int hrs = rdr["working_hours"] != DBNull.Value ? Convert.ToInt32(rdr["working_hours"]) : 0;
                                person = new Admin(id, name, phone, email, sal, full, hrs);
                            }

                            if (person != null) listPerson.Add(person);
                        }
                    }
                }
            }
            return listPerson;
        }
        public bool CheckIdExists(string id)
        {
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    long count = Convert.ToInt64(cmd.ExecuteScalar());
                    return count > 0; // Trả về true nếu đã có
                }
            }
        }
    }
}
