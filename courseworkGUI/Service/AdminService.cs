using courseworkGUI.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Service
{
    internal class AdminService:IService<Admin>
    {
        private readonly IRepository<Admin> _adminRepository ;
        public AdminService(IRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }
        PersonRepository personRepository = new PersonRepository();
        public List<Admin> GetAll() 
        {
            return _adminRepository.GetAll();
        }
        public void Add(Admin admin)
        {
            if (personRepository.CheckIdExists(admin.ID))
            {
                throw new Exception("ID already exists");
            }
            if (!CheckValidate.CheckName(admin.Name))
            {
                throw new Exception("Invalid Name");
            }
            if (!CheckValidate.CheckPhoneNumber(admin.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }
            if (!CheckValidate.CheckEmail(admin.Email))
            {
                throw new Exception("Invalid email");
            }
            if (!CheckValidate.CheckSalary(admin.Salary.ToString()))
            {
                throw new Exception("Invalid Salary");
            }
            _adminRepository.Add(admin);
        }
        public void Update(Admin admin)
        {
           
            if (!CheckValidate.CheckName(admin.Name))
            {
                throw new Exception("Invalid Name");
            }
            if (!CheckValidate.CheckPhoneNumber(admin.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }
            if (!CheckValidate.CheckEmail(admin.Email))
            {
                throw new Exception("Invalid email");
            }
            if (!CheckValidate.CheckSalary(admin.Salary.ToString()))
            {
                throw new Exception("Invalid Salary");
            }
            _adminRepository.Update(admin);
        }
        public void Delete(string id) 
        {
            _adminRepository.Delete(id);
        }
    }
}
