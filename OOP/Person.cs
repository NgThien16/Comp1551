using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Person
    {
        private int id;
        private string name;
        private int age;
        private string address;

        public Person()
        {

        }

        public Person(int id, string name, int age, string address)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.address = address;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        
    }
}
