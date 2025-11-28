using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Repository
{
    internal class StudentRepository:IRepository<Student>
    {
        public List<Student> GetAll()
        {
            List<Student> listStudent = new List<Student>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT *FROM users WHERE role ='Student'";
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
                            string subject = rdr["subjects"] != DBNull.Value ? rdr["subjects"].ToString() : "";

                            Student student = new Student(id, name, phone, email, subject);
                            listStudent.Add(student);
                        }
                    }
                }
            }
            return listStudent;
        }
        public void Add(Student student)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO users(name,phone,email,role,subjects)" + "VALUES (@n, @p, @e, 'Student', @sub)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //value 
                cmd.Parameters.AddWithValue("@n", student.Name);
                cmd.Parameters.AddWithValue("@p", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@e", student.Email);

                cmd.Parameters.AddWithValue("@sub", student.Subject);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Student student)
        {

        }
        public void Delete(string name)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM users WHERE name =@n and role ='Student'";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
