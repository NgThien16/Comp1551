using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    class Admin : Person
    {
        //attributes
        private double _salary;
        private Boolean _isFulltime;
        private int _workingHours;
        //properties
        public double Salary
        {
            get { return _salary; }
            private set
            {

                _salary = value;
            }

        }
        public Boolean IsFulltime
        {
            get { return _isFulltime; }
            private set { _isFulltime = value; }
        }
        public int WorkingHours
        {
            get { return _workingHours; }
            private set { _workingHours = value; }
        }
        public Admin(int ID, string Name, string PhoneNumber, string Email, double salary, Boolean isFullTime, int workingHours) : base(ID, Name, PhoneNumber, Email)
        {
            Salary = salary;
            IsFulltime = isFullTime;
            WorkingHours = workingHours;
        }
        public override string ToString()
        {
            return $"Name:{Name}, Phone Number:{PhoneNumber}, Email:{Email}, Salary:{Salary}, FullTime:{IsFulltime}, Working Hours:{WorkingHours}";

        }
    }
}
