using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Student:Person
    {
        private string subject;

        public Student() { }
        public Student(int id, string name, int age, string address, string subject) : base(id, name, age, address)
        {
         
            this.subject = subject;
        }
    }
}
