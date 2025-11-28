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
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT*FROM users ORDER BY role";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = Convert.ToInt32(rdr["id"]);
                            string name = rdr["name"].ToString();
                            string phone = rdr["phone"].ToString();
                            string email = rdr["email"] != DBNull.Value ? rdr["email"].ToString() : "";
                            string role = rdr["role"].ToString();

                            Person person = null;
                            if (role == "Teacher")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                string sub = rdr["subjects"] != DBNull.Value ? rdr["subjects"].ToString() : "";
                                person = new Teacher(id, name, phone, email, sal, sub);
                            }
                            else if (role == "Student")
                            {
                                string sub = rdr["subjects"] != DBNull.Value ? rdr["subjects"].ToString() : "";

                                person = new Student(id, name, phone, email, sub);
                            }
                            else if (role == "Admin")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                bool full = rdr["is_full_time"] != DBNull.Value ? Convert.ToBoolean(rdr["is_full_time"]) : false;
                                int hrs = rdr["working_hours"] != DBNull.Value ? Convert.ToInt32(rdr["working_hours"]) : 0;
                                person = new Admin(id, name, phone, email, sal, full, hrs);
                            }
                            if (person != null)
                            {
                                listPerson.Add(person);
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

            using (var conn = Database.GetConnection())
            {
                conn.Open();

                // search by name or phone
                string sql = "SELECT * FROM users WHERE name LIKE @kw OR phone LIKE @kw ORDER BY role";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    // add % at end and start to search string(Contains)
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {

                            int id = Convert.ToInt32(rdr["id"]);
                            string name = rdr["name"].ToString();
                            string phone = rdr["phone"].ToString();
                            string email = rdr["email"] != DBNull.Value ? rdr["email"].ToString() : "";
                            string role = rdr["role"].ToString();

                            Person person = null;

                            if (role == "Teacher")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                string sub = rdr["subjects"] != DBNull.Value ? rdr["subjects"].ToString() : "";
                                person = new Teacher(id, name, phone, email, sal, sub);
                            }
                            else if (role == "Student")
                            {
                                string sub = rdr["subjects"] != DBNull.Value ? rdr["subjects"].ToString() : "";
                                person = new Student(id, name, phone, email, sub);
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
    }
}
