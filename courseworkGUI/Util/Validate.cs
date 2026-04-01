using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace courseworkGUI
{
    internal class CheckValidate
    {
        public static bool CheckIdFormat(string id, string role)
        {
            if (string.IsNullOrEmpty(id)) return false;
            string expectedPrefix = "";
            switch (role)
            {
                case "Teacher": expectedPrefix = "TEA"; break;
                case "Student": expectedPrefix = "STU"; break;
                case "Admin": expectedPrefix = "ADM"; break;
                default: return false;
            }
            string pattern = $@"^{expectedPrefix}\d{{3}}$";

            return Regex.IsMatch(id, pattern);
        }
        public static bool CheckName(string name)
        {
            string regexName = @"^([A-ZÀ-Ý][a-zà-ỹ]+)\s([A-ZÀ-Ý][a-zà-ỹ]+)(\s[A-ZÀ-Ý][a-zà-ỹ]+)*$";
            return Regex.IsMatch(name, regexName);
        }

        public static bool CheckPhoneNumber (string phoneNumber)
        {
            string regexPhoneNumber = @"^[0][0-9]{9}$";
            return Regex.IsMatch (phoneNumber, regexPhoneNumber);
        }
        public static bool CheckEmail(string email)
        {
            string regexEmail = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, regexEmail);
        }
        public static bool CheckSalary(string salary) 
        {
            string regexSalary = @"^[0-9]+$";
            return Regex.IsMatch(salary, regexSalary);
        }
    }

}
