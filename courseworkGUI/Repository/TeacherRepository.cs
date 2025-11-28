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
            using(var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT *FROM users WHERE role ='Teacher'";
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

                            
                            double salary = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;

                       
                            string subject = rdr["subjects"] != DBNull.Value ? rdr["subjects"].ToString() : "";

                      
                            Teacher t = new Teacher(id, name, phone, email, salary, subject);
                            listTeacher.Add(t);
                        }
                    }
                }
            }
            return listTeacher;
        }
        public void Add(Teacher teacher)
        {
            using (var conn = Database.GetConnection()) 
            {
                conn.Open();
                string sql = "INSERT INTO users(name,phone,email,role,salary,subjects)" + "VALUES (@n, @p, @e, 'Teacher',@sal, @sub)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                //value 
                cmd.Parameters.AddWithValue("@n", teacher.Name);
                cmd.Parameters.AddWithValue("@p", teacher.PhoneNumber);
                cmd.Parameters.AddWithValue("@e", teacher.Email);

                cmd.Parameters.AddWithValue("@sal", teacher.Salary);
                cmd.Parameters.AddWithValue("@sub", teacher.Subject);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Teacher teacher) 
        {
          
        }
        public void Delete(string name)
        {
            using (var conn = Database.GetConnection()) 
            {
                conn.Open();
                string sql = "DELETE FROM users WHERE name =@n and role ='Teacher'";
                using (var cmd = new MySqlCommand(sql, conn)) 
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    
                    cmd.ExecuteNonQuery ();
                }
            }
        }

    }
}
