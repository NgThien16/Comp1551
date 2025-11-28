using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI
{
    class Teacher : Person
    {
        //attribute
        private double _salary;
        private string _subject;

        //properties
        public double Salary
        {
            get { return _salary; }
            private set
            {

                _salary = value;
            }
        }
        public string Subject
        {
            get { return _subject; }
            private set
            {

                _subject = value;
            }
        }
        
        public Teacher(int ID, string Name, string PhoneNumber, string Email, double salary, string subject) : base(ID, Name, PhoneNumber, Email)
        {
            Salary = salary;
            Subject = subject;
        }


        public override string ToString()
        {
            return $"Name:{Name}, Phone Number:{PhoneNumber}, Email:{Email}, Salary: {Salary}$, Subject:{Subject}";

        }
    }
}
