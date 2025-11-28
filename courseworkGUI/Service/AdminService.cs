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
        private AdminRepository _adminRepository = new AdminRepository();
        public List<Admin> GetAll() 
        {
            return _adminRepository.GetAll();
        }
        public void Add(Admin admin)
        {
            _adminRepository.Add(admin);
        }
        public void Update(Admin admin)
        {
            _adminRepository.Update(admin);
        }
        public void Delete(string name) 
        {
            _adminRepository.Delete(name);
        }
    }
}
