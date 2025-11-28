using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    class Student : Person
    {
        // attributes
        string _subject;

        //properties
        public string Subject
        {
            get { return _subject; }
            private set
            {
                _subject = value;
            }
        }
        public Student(int ID, string Name, string PhoneNumber, string Email, string subject) : base(ID, Name, PhoneNumber, Email)
        {

            Subject = subject;
        }
        public override string ToString()
        {
            return $"Name:{Name}, Phone Number:{PhoneNumber}, Email:{Email}, Subject:{Subject}";

        }
    }
}
