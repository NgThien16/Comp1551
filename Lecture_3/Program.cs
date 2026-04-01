using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_3
{
    internal class Program
    {
        class MyClass
        {
            private string name;
            private double? Z = null;
            public MyClass()
            {

            }
            public MyClass(string name)
            {
                this.name = name;
            }
            public String getName()
            {
                return name;
            }
            public void Logarithm (double X, double y)
            {
                Z = Math.Log (X, y);
            }
            public double? GetResult()
            {
                return (Z);
            }
        }
        public class MyProject
        {
            static void Main(string[] args)
            {
                double A = 8; 
                double B = 2;
                MyClass myObj = new MyClass();
                myObj.Logarithm (A, B);
                Console.WriteLine("The logarithm of {0} to the base {1} is {2}", A,B, myObj.GetResult());
                Calculator.Add(10, 5);
                

            }
        }
    }
}
