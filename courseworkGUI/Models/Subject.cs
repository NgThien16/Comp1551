using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseworkGUI.Models
{
    internal class Subject
    {
        private int _subject_id;
        private string _subject_code;
        private string _name;
        private int _credit;

        public int ID 
        {
            get { return _subject_id; }
            private set { _subject_id = value; }
        }
        public string SubjectCode
        {
            get { return _subject_code; }
            private set { _subject_code = value; }
        }
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public int Credit
        {
            get { return _credit; }
            private set { _credit = value; }
        }
        public Subject(int subject_id, string subject_code, string name, int credit)
        {
            _subject_id = subject_id;
            _subject_code = subject_code;
            Name = name;
            Credit = credit;
        }
    }
}
