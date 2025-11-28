using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Repository
{
    internal class AdminRepository:IRepository<Admin>
    {
        public List<Admin> GetAll() 
        {
            List<Admin> listAdmin = new List<Admin>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "SELECT *FROM users WHERE role ='Admin'";
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
                            bool isFullTime = rdr["is_full_time"] != DBNull.Value ? Convert.ToBoolean(rdr["is_full_time"]) : false;
                            int workingHours = rdr["working_hours"] != DBNull.Value ? Convert.ToInt32(rdr["working_hours"]) : 0;
                            Admin newAdmin = new Admin(id, name, phone, email, salary, isFullTime, workingHours);
                            listAdmin.Add(newAdmin);
                        }
                    }
                }
            }
            return listAdmin;
        }
        public void Add(Admin admin) 
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO users(name,phone,email,role,salary,is_full_time,working_hours)" + "VALUES (@n, @p, @e, 'Admin',@sal,@fulltime,@wh)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //value 
                cmd.Parameters.AddWithValue("@n", admin.Name);
                cmd.Parameters.AddWithValue("@p", admin.PhoneNumber);
                cmd.Parameters.AddWithValue("@e", admin.Email);

                cmd.Parameters.AddWithValue("@sal", admin.Salary);
                cmd.Parameters.AddWithValue("@fulltime", admin.IsFulltime);
                cmd.Parameters.AddWithValue("@wh", admin.WorkingHours);
                cmd.ExecuteNonQuery();
            }
        }


        public void Update(Admin admin)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE users 
                       SET name=@n, phone=@p, email=@e, salary=@sal, is_full_time=@full, working_hours=@wh 
                       WHERE id=@id AND role='Admin'";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", admin.Name);
                    cmd.Parameters.AddWithValue("@p", admin.PhoneNumber);
                    cmd.Parameters.AddWithValue("@e", admin.Email);
                    cmd.Parameters.AddWithValue("@sal", admin.Salary);

                    // Tham số riêng
                    cmd.Parameters.AddWithValue("@full", admin.IsFulltime);
                    cmd.Parameters.AddWithValue("@wh", admin.WorkingHours);

                    cmd.Parameters.AddWithValue("@id", admin.ID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(string name)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM users WHERE name =@n and role ='Admin'";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
