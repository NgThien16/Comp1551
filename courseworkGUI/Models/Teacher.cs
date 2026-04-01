using System;
using System.Collections.Generic;

namespace courseworkGUI
{
    class Teacher : Person
    {
        // Attribute
        private double _salary;
        private int _subjectId;

        // Properties
        public double Salary
        {
            get { return _salary; }
            private set { _salary = value; }
        }

        public int SubjectID
        {
            get { return _subjectId; }
            private set { _subjectId = value; }
        }


        public string SubjectDisplay { get; set; }

        public Teacher(string ID, string Name, string PhoneNumber, string Email, double salary, int subjectId, string subjectDisplay = "")
            : base(ID, Name, PhoneNumber, Email, "Teacher")
        {
            Salary = salary;
            SubjectID = subjectId;
            SubjectDisplay = subjectDisplay; 
        }

        public override string ToString()
        {
            // 
            return $"Name:{Name}, Salary: {Salary}$, Subjects: {SubjectDisplay}";
        }
    }
}