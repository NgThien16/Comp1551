using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    class EducationCentreSystem
    {

        private string connString = "server=localhost;user=root;database=education_db;port=3306;password=codegym;";

        //connect database 
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
        //add function
        public void Add(Role role)
        {

            try
            {
                Console.WriteLine($"\n--- Add New {role}  ---");
                string name;
                do {
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    if (!Validate.CheckName(name))
                    {
                        Console.WriteLine("Invalid, please try again");
                    }
                }while(!Validate.CheckName(name));

                string phone;
                do
                {
                    Console.Write("Phone Number: ");
                    phone = Console.ReadLine();
                    if (!Validate.CheckPhoneNumber(phone))
                    {
                        Console.WriteLine("Invalid, start with '0' and 10 numbers");
                    }
                }while(!Validate.CheckPhoneNumber(phone));

                string email;
                do {
                    Console.Write("Email: ");
                    email = Console.ReadLine();
                    if (!Validate.CheckEmail(email))
                    {
                        Console.WriteLine("Invalid, ex:thien@gmail.com");
                    }
                }while(!Validate.CheckEmail(email));
                string sql = "";
                MySqlCommand cmd;

                // connect and save data
                using (var conn = GetConnection())
                {
                    conn.Open();
                    switch (role)
                    {
                        case Role.Teacher:
                            Console.Write("Salary: ");
                            double salaryTeacher = double.Parse(Console.ReadLine());
                            Console.Write("Subject: ");
                            string subjectTeacher = Console.ReadLine();
                            sql = @"INSERT INTO users (name, phone, email, role, salary, subjects)VALUES (@n, @p, @e, 'Teacher', @sal, @sub)";

                            cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@sal", salaryTeacher);
                            cmd.Parameters.AddWithValue("@sub", subjectTeacher);

                            break;
                        case Role.Student:

                            Console.Write("Subject: ");
                            string subject = Console.ReadLine();
                            sql = @"INSERT INTO users (name, phone, email, role,subjects)VALUES (@n, @p, @e, 'Student', @sub)";

                            cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@sub", subject);

                            break;
                        case Role.Admin:
                            Console.Write("Salary: ");
                            double salaryAdmin = double.Parse(Console.ReadLine());
                            Console.Write("Full Time (true/false): ");
                            bool full = bool.Parse(Console.ReadLine());
                            Console.Write("Working Hours: ");
                            int hours = int.Parse(Console.ReadLine());

                            sql = @"INSERT INTO users (name, phone, email, role, salary, is_full_time, working_hours)VALUES (@n, @p, @e, 'Admin', @sal, @full, @hrs)";

                            cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@sal", salaryAdmin);
                            cmd.Parameters.AddWithValue("@full", full);
                            cmd.Parameters.AddWithValue("@hrs", hours);
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            return;
                    }
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@p", phone);
                    cmd.Parameters.AddWithValue("@e", email);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"=> Add New {role} Successfully!");
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
        }
        //Display by role function
        public void DisplayByRole(Role role)
        {
            Console.WriteLine($"\n--- List {role} ---");
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE role = @r";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@r", role.ToString());

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        //get data from database
                        int id = Convert.ToInt32(rdr["id"]);
                        string name = rdr["name"].ToString();
                        string phone = rdr["phone"].ToString();
                        string email = rdr["email"] == DBNull.Value ? "" : rdr["email"].ToString();

                        Person p = null;

                        switch (role)
                        {
                            case Role.Teacher:
                                double salary = rdr["salary"] == DBNull.Value ? 0 : Convert.ToDouble(rdr["salary"]);
                                p = new Teacher(id, name, phone, email, salary, rdr["subjects"].ToString());
                                break;
                            case Role.Student:
                                p = new Student(id, name, phone, email, rdr["subjects"].ToString());
                                break;
                            case Role.Admin:
                                p = new Admin(id, name, phone, email, Convert.ToDouble(rdr["salary"]), Convert.ToBoolean(rdr["is_full_time"]), Convert.ToInt32(rdr["working_hours"]));
                                break;
                        }
                        Console.WriteLine(p.ToString());
                    }
                }
            }

        }
        // delete function
        public void Delete(Role role)
        {

            Console.WriteLine($"\n--- Delete {role} ---");
            Console.WriteLine("Input name to delete: ");
            string deleteName = Console.ReadLine();
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = @"DELETE FROM users WHERE role = @r AND name = @name";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@r", role.ToString());
                    cmd.Parameters.AddWithValue("@name", deleteName);

                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        Console.WriteLine("Delete Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No matching record");
                    }
                }
                ;

            }

        }
        // update function
        public void Update(Role role)
        {
            Console.WriteLine($"Update {role}");
            Console.WriteLine("Input name to update");
            string oldName = Console.ReadLine();

            string name;
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (!Validate.CheckName(name))
                {
                    Console.WriteLine("Invalid, please try again");
                }
            } while (!Validate.CheckName(name));

            string phone;
            do
            {
                Console.Write("Phone Number: ");
                phone = Console.ReadLine();
                if (!Validate.CheckPhoneNumber(phone))
                {
                    Console.WriteLine("Invalid, start with '0' and 10 numbers");
                }
            } while (!Validate.CheckPhoneNumber(phone));

            string email;
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (!Validate.CheckEmail(email))
                {
                    Console.WriteLine("Invalid, ex:thien@gmail.com");
                }
            } while (!Validate.CheckEmail(email));



            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "";
                MySqlCommand cmd;
                switch (role)
                {
                    case Role.Teacher:
                        Console.Write("Salary: ");
                        double salaryTeacher = double.Parse(Console.ReadLine());
                        Console.Write("Subject: ");
                        string subjectTeacher = Console.ReadLine();
                        sql = @"UPDATE users SET name=@n, phone=@p, email=@e, salary=@sal, subjects=@sub WHERE name=@oldName AND role='Teacher'";

                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@sal", salaryTeacher);
                        cmd.Parameters.AddWithValue("@sub", subjectTeacher);

                        break;
                    case Role.Student:

                        Console.Write("Subject: ");
                        string subject = Console.ReadLine();
                        sql = @"UPDATE users SET name=@n, phone=@p, email=@e, subjects=@sub WHERE name=@oldName AND role='Student'";

                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@sub", subject);

                        break;
                    case Role.Admin:
                        Console.Write("Salary: ");
                        double salaryAdmin = double.Parse(Console.ReadLine());
                        Console.Write("Full Time (true/false): ");
                        bool full = bool.Parse(Console.ReadLine());
                        Console.Write("Working Hours: ");
                        int hours = int.Parse(Console.ReadLine());

                        sql = @"UPDATE users
                        SET name=@n, phone=@p, email=@e, salary=@sal, is_full_time=@full, working_hours=@hrs WHERE name=@oldName AND role='Admin'";

                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@sal", salaryAdmin);
                        cmd.Parameters.AddWithValue("@full", full);
                        cmd.Parameters.AddWithValue("@hrs", hours);
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        return;
                }
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@p", phone);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@oldName", oldName);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine($"=> Update {role} Successfully!");
                }
                else
                {
                    Console.WriteLine("Not found name");
                }

            }

        }


        public void DisplayAll()
        {
            Console.WriteLine($"\n--- LIST ALL USERS ---");
            using (var conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM users ORDER BY role";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        try
                        {

                            int id = Convert.ToInt32(rdr["id"]);
                            string name = rdr["name"].ToString();
                            string phone = rdr["phone"].ToString();
                            string email = rdr["email"].ToString();


                            string currentRole = rdr["role"].ToString();

                            Person p = null;


                            if (currentRole == "Teacher")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                string sub = rdr["subjects"].ToString();
                                p = new Teacher(id, name, phone, email, sal, sub);
                            }
                            else if (currentRole == "Student")
                            {
                                string subjects = rdr["subjects"].ToString();
                                p = new Student(id, name, phone, email, subjects);
                            }
                            else if (currentRole == "Admin")
                            {
                                double sal = rdr["salary"] != DBNull.Value ? Convert.ToDouble(rdr["salary"]) : 0;
                                bool full = rdr["is_full_time"] != DBNull.Value && Convert.ToBoolean(rdr["is_full_time"]);
                                int hours = rdr["working_hours"] != DBNull.Value ? Convert.ToInt32(rdr["working_hours"]) : 0;
                                p = new Admin(id, name, phone, email, sal, full, hours);
                            }


                            if (p != null)
                            {
                                Console.WriteLine(p.ToString());
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"[Lỗi data ID {rdr["id"]}]: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}