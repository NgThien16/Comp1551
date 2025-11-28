using courseworkGUI.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace courseworkGUI
{
    //enum
    public enum Role
    {
        Teacher,
        Student,
        Admin
    }
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        TeacherService teacherService = new TeacherService();
        StudentService studentService = new StudentService();
        AdminService adminService = new AdminService();
        private void LoadData()
        {
            try
            {
                // 1. Kiểm tra xem người dùng đang chọn hiển thị Role nào
                if (cbbRecord.SelectedItem == null) return;

                string currentRole = cbbRecord.SelectedItem.ToString();

                // 2. Reset dữ liệu cũ trên bảng đi
                dgvRecord.DataSource = null;
                dgvRecord.Rows.Clear(); // Dòng này chỉ chạy nếu DataSource null, giúp bảng sạch sẽ

                // 3. Phân loại để gọi Service tương ứng
                if (currentRole == "Teacher")
                {
                    
                    dgvRecord.DataSource = teacherService.GetAll(); // Gọi hàm lấy danh sách Teacher

                    //hide ID
                    if (dgvRecord.Columns["ID"] != null) dgvRecord.Columns["ID"].Visible = false;
                }
                else if (currentRole == "Student")
                {
                    
                    dgvRecord.DataSource = studentService.GetAll();
                }
                else if (currentRole == "Admin")
                {
                    // AdminService service = new AdminService();
                    // dtgData.DataSource = service.GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message);
            }
        }

        private void cbbRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbRecord.SelectedItem == null) return;
            string choice = cbbRecord.SelectedItem.ToString();
            if(choice == "Teacher")
            {
               
                dgvRecord.DataSource = teacherService.GetAll();
            }else if(choice == "Student")
            {
                dgvRecord.DataSource = studentService.GetAll();
            }else if(choice == "Admin")
            {
                dgvRecord.DataSource = adminService.GetAll();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                dgvRecord.DataSource = Search.SearchUsers(keyword);
            }
            else
            {
                Console.WriteLine("Error");
            }
     
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbbRole.SelectedItem == null)
            {
                MessageBox.Show("Please, choose role (Teacher/Student/Admin)!");
                return;
            }
            string selectedRole = cbbRole.SelectedItem.ToString().Trim();
            ;
            try
            {
                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                switch (selectedRole) 
                {
                    case "Teacher":
                        double salaryT = 0;
                        double.TryParse(txtSalary.Text, out salaryT); 
                        string subjectT = txtSubject.Text.Trim();     

                        Teacher newTeacher = new Teacher(0, name, phone, email, salaryT, subjectT);

                        
                        teacherService.Add(newTeacher);
                        break;

                    case "Student":
                        
                        string subjectS = txtSubject.Text.Trim();
                        Student newStudent = new Student(0, name, phone, email, subjectS);
                        studentService.Add(newStudent);
                        break;

                    case "Admin":
                        
                        double salaryA = 0;
                        double.TryParse(txtSalary.Text, out salaryA);

                        bool isFullTime =false;
                        if (rbYes.Checked)
                        {
                            isFullTime = true;
                        }
                        int workingHours = 0;
                        int.TryParse(txtWorkingHours.Text, out workingHours);
                        Admin newAdmin = new Admin(0, name, phone, email, salaryA, isFullTime, workingHours);

                        
                        adminService.Add(newAdmin);
                        break;
                }
                MessageBox.Show($"Add new {selectedRole} Successfully");

                LoadData();

            }
            catch(Exception ex)  
            {
                MessageBox.Show("Error:"+ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //check combo box role
                if (cbbRole.SelectedItem == null)
                {
                MessageBox.Show("Please select a role to delete");
                return;
                 }
                string deleteName = txtName.Text.Trim();
            //check name
                if (string.IsNullOrEmpty(deleteName))
                {
                MessageBox.Show("Please enter name to delete");
                return;
                }
          
                // confirm box
                DialogResult dialog = MessageBox.Show($"Do you want to delete{cbbRole.Text}: '{deleteName}'?",
                                                       "Confirm",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                   string currentRole = cbbRole.SelectedItem.ToString();
                    switch (currentRole) 
                    {
                        case "Teacher":
                            teacherService.Delete(deleteName);
                            break;
                        case "Student":
                            studentService.Delete(deleteName);
                            break;
                        case "Admin":
                            adminService.Delete(deleteName);
                            break;
                    }
                    MessageBox.Show("Delete Successfully");

                    LoadData();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error: "+  ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtSalary.Text = "";
        }
    }
}
