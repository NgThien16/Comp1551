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
        PersonService personService = new PersonService();
        private void LoadData()
        {
            try
            {
                // check user choose role
                if (cbbRecord.SelectedItem == null) return;

                string currentRole = cbbRecord.SelectedItem.ToString();
                //Reset old data
                dgvRecord.DataSource = null;
                dgvRecord.Rows.Clear(); // it run when datasourse = null
                if (currentRole == "Teacher")
                {  
                    dgvRecord.DataSource = teacherService.GetAll(); // Gọi hàm lấy danh sách Teacher
                    //hide ID
                    if (dgvRecord.Columns["ID"] != null) dgvRecord.Columns["ID"].Visible = false;
                }
                else if (currentRole == "Student")
                {
                    dgvRecord.DataSource = studentService.GetAll();
                    if (dgvRecord.Columns["ID"] != null) dgvRecord.Columns["ID"].Visible = false;
                }
                else if (currentRole == "Admin")
                {
                    dgvRecord.DataSource = adminService.GetAll(); 
                    //hide ID
                    if (dgvRecord.Columns["ID"] != null) dgvRecord.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message);
            }
        }
        
        private bool CheckInput()
        {
            errorProvider1.Clear();
            bool isValid = true;
            if (!CheckValidate.CheckName(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Name must be valid! Capitalize the first letter, EX: David Luis or Nguyen Van A)");
                isValid = false;
            }
            if (!CheckValidate.CheckPhoneNumber(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Phone number must start with 0 and must have 10 numbers!");
                isValid = false;
            }
            if (!CheckValidate.CheckEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Invalid (Ex: abc@gmail.com)");
                isValid = false;
            }
            if (!string.IsNullOrEmpty(txtSalary.Text))
            {
                if (!CheckValidate.CheckSalary(txtSalary.Text))
                {
                    errorProvider1.SetError(txtSalary, "Please, input number");
                    isValid = false;
                }
            }
            return isValid;
        }

        private void cbbRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbRecord.SelectedItem == null) return;
            string choice = cbbRecord.SelectedItem.ToString();

            if (choice == "All")
            {
                dgvRecord.DataSource = personService.GetAll();
            }
            else if(choice == "Teacher")
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
                dgvRecord.DataSource = personService.SearchUsers(keyword);
            }
            else
            {
                Console.WriteLine("Error");
            }
     
        }

        private void btnAdd_Click(object sender, EventArgs e)        
        {
            if (CheckInput() == false)
            {
                MessageBox.Show("Please, check red error, data not fix"); 
            }
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
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtSalary.Text = "";
            txtWorkingHours.Text = "";
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
            txtWorkingHours.Text = ""; 
        }

        private void Home_Load(object sender, EventArgs e)
        {
            cbbRecord.SelectedIndex = 0;
            cbbRole.SelectedIndex = 0;
        }
        int selectedId = -1;// to update
        private void dgvRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // next if click row

            // get current row
            DataGridViewRow row = dgvRecord.Rows[e.RowIndex];
            // get id
            var currentPerson = row.DataBoundItem as Person;

            if (currentPerson != null)
            {
                selectedId = currentPerson.ID;
                txtName.Text = currentPerson.Name;
                txtPhone.Text = currentPerson.PhoneNumber;
                txtEmail.Text = currentPerson.Email;

                if (currentPerson is Teacher) cbbRole.SelectedItem = "Teacher";
                else if (currentPerson is Student) cbbRole.SelectedItem = "Student";
                else if (currentPerson is Admin) cbbRole.SelectedItem = "Admin";
            
                if (currentPerson is Teacher)
                {
                    Teacher t = (Teacher)currentPerson;
                    txtSalary.Text = t.Salary.ToString(); 
                    txtSubject.Text = t.Subject;

                    grpFullTime.Visible = false;
                }
                else if (currentPerson is Student)
            {
                    Student s = (Student)currentPerson;
                    txtSubject.Text = s.Subject;
            }
                else if (currentPerson is Admin)
            {
                    Admin a = (Admin)currentPerson;
                    txtSalary.Text = a.Salary.ToString();
                    txtWorkingHours.Text = a.WorkingHours.ToString();

                    // Radio Button
                    if (a.IsFulltime) rbYes.Checked = true;
                    else rbNo.Checked = true;

                    grpFullTime.Visible = true;
            }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // check if any lines selected 
            if (selectedId == -1)
            {
                MessageBox.Show("Please, click on table choose users to update!");
                return;
            }
            if (CheckInput() == false) return;

            try
            {
                string role = cbbRole.SelectedItem.ToString();

                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();

                switch (role)
                {
                    case "Teacher":
                        double salT = double.Parse(txtSalary.Text);
                        string subT = txtSubject.Text;
                        Teacher teacher = new Teacher(selectedId, name, phone, email, salT, subT);
                        teacherService.Update(teacher);
                        break;
                    case "Student":
                        string subS = txtSubject.Text;
                        Student student = new Student(selectedId, name, phone, email, subS);
                        studentService.Update(student);
                        break;
                    case "Admin":
                        double salA = double.Parse(txtSalary.Text);
                        int wh = int.Parse(txtWorkingHours.Text);
                        bool isFull = rbYes.Checked;
                        Admin admin = new Admin(selectedId, name, phone, email, salA, isFull, wh);
                        adminService.Update(admin);
                        break;
                }
                MessageBox.Show("Update Successfully!");
                LoadData();
                // delete input và reset ID
                selectedId = -1;
                txtName.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtSubject.Text = "";
                txtSalary.Text = "";
                txtWorkingHours.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
            if (cbbRole.SelectedItem == null) return;
            string role = cbbRole.SelectedItem.ToString();

            // hide label and input salary
            txtSalary.Visible = false;
            lblSalary.Visible = false;
            // hide label and input subject
            txtSubject.Visible = false;
            lblSubject.Visible = false;

            //hide label and input workinghourse
            txtWorkingHours.Visible = false;
            lblWorkingHours.Visible = false;

            // // hide groupbox fulltime
            grpFullTime.Visible = false;

            switch (role)
            {
                case "Teacher":
                    //display salary
                    txtSalary.Visible = true;
                    lblSalary.Visible = true;
                    //subject
                    txtSubject.Visible = true;
                    lblSubject.Visible = true;
                    break;
                case "Student":
                    //display subject
                    txtSubject.Visible = true;
                    lblSubject.Visible = true;
                    break;

                case "Admin":
                   // display Salary
                    txtSalary.Visible = true;
                    lblSalary.Visible = true;
                    // working hours
                    txtWorkingHours.Visible = true;
                    lblWorkingHours.Visible = true;
                    // is full time
                    grpFullTime.Visible = true;
                    break;

                case "All":
                    txtSalary.Visible = true; lblSalary.Visible = true;
                    txtSubject.Visible = true; lblSubject.Visible = true;
                    txtWorkingHours.Visible = true; lblWorkingHours.Visible = true;
                    grpFullTime.Visible = true;
                    break;
            }
        }
    }
}
