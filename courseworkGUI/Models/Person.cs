using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI
{
    abstract class Person
    {
        // attributes 
        private string  _id;
        private string _name;
        private string _phoneNumber;
        private string _email;
        private string _role;
        //properties
        public string ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            private set
            {

                _name = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            private set
            {
                _phoneNumber = value;
            }
        }
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }
        public string Role
        {
            get { return _role; }
            private set { _role = value; }
        }

        public Person(String id, string name, string phoneNumber, string email, string role)
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Role = role;
        }
        //override ToString
        public abstract string ToString();

    }
}
