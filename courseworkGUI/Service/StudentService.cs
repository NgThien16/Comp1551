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
        private StudentRepository _studentRepository = new StudentRepository();
        public List<Student> GetAll() 
        {
            return _studentRepository.GetAll(); 
        }
        public void Add(Student student)
        {
            _studentRepository.Add(student);
        }
        public void Update(Student student) 
        {
            _studentRepository.Update(student);
        }
        public void Delete(string name)
        {
            _studentRepository.Delete(name);
        }
    }
}
