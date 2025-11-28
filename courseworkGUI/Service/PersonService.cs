using courseworkGUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Service
{
    internal class PersonService
    {
        PersonRepository _personRepository = new PersonRepository();
        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }
        public List<Person> SearchUsers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _personRepository.GetAll();
            }
            return _personRepository.SearchUsers(keyword);
        }
    }
}
