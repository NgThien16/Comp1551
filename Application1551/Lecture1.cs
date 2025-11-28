using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1551
{
    internal class Lecture1
    {
        static void Main(string[] args)
        {
            //print 

            System.Console.WriteLine("Hello World");

            //datatype
            String str = "Thien";
            int IntegerNumber = 5;
            double RealNumber = 5.5;
            char Symbol = 'A';
            string Text = "Hello";
            bool Flag = true;
            Console.WriteLine(IntegerNumber.GetType());
            Console.WriteLine(RealNumber);
            Console.WriteLine(Symbol);
            Console.WriteLine(Text);
            Console.WriteLine(Flag);
            System.Console.Write("My name is " + str);
            int UserInput;
            
            // input value
            Console.WriteLine("Enter a value");
            UserInput = Convert.ToInt32(Console.ReadLine());
            
            //if codition
            Flag = (UserInput > 0);
            Console.WriteLine("The value is positive, {0}", Flag);
            if (UserInput > 0)
                Console.WriteLine("The Value is positive");
            else
                Console.WriteLine("The value is negative or 0");

            //for loop
            int i;
            int limit;
            Console.WriteLine("When you want to stop the loop?");
            limit=int.Parse(Console.ReadLine());
            for (i = 0; i <= 100; i++)
            {
              
                if (i % 2 == 0 && i !=0)
                    Console.WriteLine(i);
                if (i == limit) 
                break;
            }

            // Array
            //option 1
            string[] Array = { "Apple", "Mango", "Banana" };
            //option 2 
            string[] Array2 = new string[10];
            Array2[0] = "Hello";
            Array2[1] = "Apple";
            Array2[2] = "Tulip";
           // duyệt mảng 
           //option1
           for( i=0; i < Array2.Length; i++)
                if (Array2[i] !=null)
                    //Console.WriteLine(Array[i]);
                    Console.WriteLine($"Array[{i}] = {Array2[i]}");
            // option 2
            foreach(string s in Array)
            {
                Console.WriteLine(s);
            }

        }
    }
}
