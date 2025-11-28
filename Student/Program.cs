
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        private string name;
        private double scienceGrades;
        private double mathGrades;
        private double englishGrades;
        public string Name { get { return name; } set { name = value; } }
        public double ScienceGrades { get { return scienceGrades; } set { scienceGrades= value; } } 
        public double MathGrades { get { return mathGrades; } set { mathGrades= value; } } 
        public double EnglishGrades { get { return englishGrades; } set { englishGrades= value; } } 
        public Student()
        { }
        public Student(string name, double scienceGrades, double mathGrades, double englishGrades)
        {
            this.name = name;
            this.scienceGrades = scienceGrades;
            this.mathGrades = mathGrades;
            this.englishGrades = englishGrades;
        }
        public void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Math: {mathGrades}, Science: {scienceGrades}, English: {englishGrades}");
        }
        public void GetAverageGrade()
        {
            double sum = (scienceGrades + mathGrades + englishGrades) / 3; 
            Console.WriteLine($"Average {name}: {sum}");
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                //Data for 3 students
                Student[] students = new Student[3];
                students[0] = new Student("Thien", 8.0, 9.0, 9.0);
                students[1] = new Student("Lucas", 6.0, 9.0, 7.0);
                students[2] = new Student("David", 5.0, 7.0, 9.0);

                for(int i =0; i<3; i++)
                {
                    students[i].GetInfo();
                }

                for (int i = 0; i < 3; i++)
                {
                    students[i].GetAverageGrade();
                }
            }

        }
    }
}
