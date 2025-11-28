using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using courseworkGUI.Repository;
using Mysqlx.Crud;


namespace courseworkGUI.Service
{
    internal class TeacherService:IService<Teacher>
    {
        private TeacherRepository _teacherRepository = new TeacherRepository();
        public void Add(Teacher teacher)
        { 
            _teacherRepository.Add(teacher);
        }
        public List<Teacher> GetAll() {
           return _teacherRepository.GetAll();
        }
        public void Update(Teacher teacher)
        {
             _teacherRepository.Update(teacher);
        }
        public void Delete(string name) 
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Please, input name to delete");
            }
            _teacherRepository.Delete(name);
        }
    }
}
