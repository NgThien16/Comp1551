using courseworkGUI.Repository;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace courseworkGUI.Service
{
    internal class TeacherService:IService<Teacher>
    {
        private readonly IRepository<Teacher> _teacherRepository;
        public TeacherService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }
        PersonRepository personRepository = new PersonRepository();
        public void Add(Teacher teacher)
        {
            if (personRepository.CheckIdExists(teacher.ID))
            {
                throw new Exception("ID already exists");
            }
            if (!CheckValidate.CheckName(teacher.Name))
            {
                throw new Exception("Invalid Name");
            }
            if (!CheckValidate.CheckPhoneNumber(teacher.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }
            if (!CheckValidate.CheckEmail(teacher.Email))
            {
                throw new Exception("Invalid email");
            }
            if (!CheckValidate.CheckSalary(teacher.Salary.ToString()))
            {
                throw new Exception("Invalid Salary");
            }
            

            _teacherRepository.Add(teacher);
        }
        public List<Teacher> GetAll() {
           return _teacherRepository.GetAll();
        }
        public void Update(Teacher teacher)
        {
            if (!CheckValidate.CheckName(teacher.Name))
            {
                throw new Exception("Invalid Name");
            }
            if (!CheckValidate.CheckPhoneNumber(teacher.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }
            if (!CheckValidate.CheckEmail(teacher.Email))
            {
                throw new Exception("Invalid email");
            }
            if (!CheckValidate.CheckSalary(teacher.Salary.ToString()))
            {
                throw new Exception("Invalid Salary");
            }
           
            _teacherRepository.Update(teacher);
        }
        public void Delete(string id) 
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("Please, input id to delete");
            }
            _teacherRepository.Delete(id);
        }
    }
}
