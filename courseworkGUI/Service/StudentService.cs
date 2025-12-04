using courseworkGUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Service
{
    internal class StudentService:IService<Student>
    {
        private IRepository<Student> _studentRepository;
        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public List<Student> GetAll() 
        {
            return _studentRepository.GetAll(); 
        }
        PersonRepository personRepository = new PersonRepository();
        public void Add(Student student)
        {
            if (personRepository.CheckIdExists(student.ID))
            {
                throw new Exception("ID existed");
            }
            if (!CheckValidate.CheckName(student.Name))
            {
                throw new Exception("Invalid Name");
            }
            if (!CheckValidate.CheckPhoneNumber(student.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }
            if (!CheckValidate.CheckEmail(student.Email))
            {
                throw new Exception("Invalid email");
            }
           
            _studentRepository.Add(student);
        }
        public void Update(Student student) 
        {
            
            if (!CheckValidate.CheckName(student.Name))
            {
                throw new Exception("Invalid Name");
            }
            if (!CheckValidate.CheckPhoneNumber(student.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }
            if (!CheckValidate.CheckEmail(student.Email))
            {
                throw new Exception("Invalid email");
            }
            
            _studentRepository.Update(student);
        }
        public void Delete(string id)
        {
            _studentRepository.Delete(id);
        }
    }
}
