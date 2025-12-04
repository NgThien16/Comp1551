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
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT u.*, s.name AS subject_name 
                           FROM users u
                           LEFT JOIN subjects s ON u.subject_id = s.subject_id
                           WHERE u.role = 'Student'"; ;
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

                            int subId = rdr["subject_id"] != DBNull.Value ? Convert.ToInt32(rdr["subject_id"]) : 0;
                            string subName = rdr["subject_name"] != DBNull.Value ? rdr["subject_name"].ToString() : "";

                            Student student = new Student(id, name, phone, email, subId, subName);
                            listStudent.Add(student);
                        }
                    }
                }
            }
            return listStudent;
        }
        public void Add(Student student)
        {
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO users(id, name, phone, email, role, subject_id) " +
                          "VALUES(@id, @n, @p, @e, 'Student', @subId)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //value 
                cmd.Parameters.AddWithValue("@id", student.ID);
                cmd.Parameters.AddWithValue("@n", student.Name);
                cmd.Parameters.AddWithValue("@p", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@e", student.Email);

                cmd.Parameters.AddWithValue("@subId", student.SubjectID);
                
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Student student)
        {
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE users 
                           SET name=@n, phone=@p, email=@e, subject_id=@subId 
                           WHERE id=@id AND role='Student'";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", student.Name);
                    cmd.Parameters.AddWithValue("@p", student.PhoneNumber);
                    cmd.Parameters.AddWithValue("@e", student.Email);
                    cmd.Parameters.AddWithValue("@subId", student.SubjectID);
                    cmd.Parameters.AddWithValue("@id", student.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string id)
        {
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM users WHERE id =@id and role ='Student'";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
