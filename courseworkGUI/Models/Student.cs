using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI
{
    class Student : Person
    {
        // attributes
        private int _subjectId;

        //properties
        public int SubjectID
        {
            get { return _subjectId; }
            private set
            {
                _subjectId = value;
            }
        }
        public string SubjectDisplay { get; set; }
        public Student(string ID, string Name, string PhoneNumber, string Email, int subjectId, string subjectDisplay="") : base(ID, Name, PhoneNumber, Email, "Student")
        {

            SubjectID = subjectId;
            SubjectDisplay = subjectDisplay;
        }
        public override string ToString()
        {
            return $"Name:{Name}, Phone Number:{PhoneNumber}, Email:{Email}, Subject:{SubjectID}";

        }
    }
}
