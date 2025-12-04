using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace courseworkGUI.Repository
{
    internal class TeacherRepository:IRepository<Teacher>
    {
        public List<Teacher> GetAll()
        {
            List<Teacher> listTeacher = new List<Teacher>();
            using(var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT u.*, s.name AS subject_name 
                           FROM users u
                           LEFT JOIN subjects s ON u.subject_id = s.subject_id
                           WHERE u.role = 'Teacher'";
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


                            double salary = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                            int subId = rdr["subject_id"] != DBNull.Value ? Convert.ToInt32(rdr["subject_id"]) : 0;
                            string subName = rdr["subject_name"] != DBNull.Value ? rdr["subject_name"].ToString() : "";


                            Teacher t = new Teacher(id, name, phone, email, salary, subId,subName);
                            listTeacher.Add(t);
                        }
                    }
                }
            }
            return listTeacher;
        }
        public void Add(Teacher teacher)
        {
            using (var conn = Database.Instance.GetConnection()) 
            {
                conn.Open();
                string sql = "INSERT INTO users(id, name, phone, email, role, salary, subject_id) " +
                          "VALUES(@id, @n, @p, @e, 'Teacher', @sal, @subId)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                //value 
                cmd.Parameters.AddWithValue("@n", teacher.Name);
                cmd.Parameters.AddWithValue("@id", teacher.ID);
                cmd.Parameters.AddWithValue("@p", teacher.PhoneNumber);
                cmd.Parameters.AddWithValue("@e", teacher.Email);

                cmd.Parameters.AddWithValue("@sal", teacher.Salary);
                cmd.Parameters.AddWithValue("@subId", teacher.SubjectID);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Teacher teacher)
        {
            using (var conn = Database.Instance.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE users 
                           SET name=@n, phone=@p, email=@e, salary=@sal, subject_id=@subId
                           WHERE id=@id AND role='Teacher'";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                  
                    cmd.Parameters.AddWithValue("@n", teacher.Name);
                    cmd.Parameters.AddWithValue("@p", teacher.PhoneNumber);
                    cmd.Parameters.AddWithValue("@e", teacher.Email);
                    cmd.Parameters.AddWithValue("@sal", teacher.Salary);
                    cmd.Parameters.AddWithValue("@subId", teacher.SubjectID);

                    cmd.Parameters.AddWithValue("@id", teacher.ID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string id)
        {
            using (var conn = Database.Instance.GetConnection()) 
            {
                conn.Open();
                string sql = "DELETE FROM users WHERE id =@id and role ='Teacher'";
                using (var cmd = new MySqlCommand(sql, conn)) 
                {
                    cmd.Parameters.AddWithValue("@id", id);        
                    cmd.ExecuteNonQuery ();
                }
            }
        }
       
    }
}
