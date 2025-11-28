using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Globalization;

namespace Tutorial2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //part2: userInput and Validation
            int number;
            Console.WriteLine("Input a number to square root");
            number = Convert.ToInt32(Console.ReadLine());

            if (number > 0)
                Console.WriteLine(number + " has a square root is: " + Math.Sqrt(number));
            else
                Console.WriteLine("Please input number greater than 0!");
            //part 3: Array Integer

            int[] array = { 4, 2, 15, 22, 9, 5, 8, 13, 3, 10 };

            // display value with index

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Array[{i}] = {array[i]}");
            }

            //Find Max and min 

            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine("Maximum number of array is " + max);
            Console.WriteLine("Minimum number of array is " + min);

            //Array sort

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }


                }
            }
            Console.WriteLine("Array after sorting:");
            foreach (int num in array)
            {
                Console.WriteLine(num + " ");
            }

            //Average
            Console.WriteLine("Average: " + array.Average());
            //Median Calculate
            double median;
            int n = array.Length;
            if (n % 2 == 1) // số phần tử lẻ
            {
                median = array[n / 2];
            }
            else // số phần tử chẵn
            {
                median = (array[(n / 2) - 1] + array[n / 2]) / 2.0;
            }
            Console.WriteLine("Median: " + median);

            // Use DateTimeFormatInfo for current culture
            DateTimeFormatInfo dtInfo = new CultureInfo("en-EN").DateTimeFormat;
            String[] months = new string[12];
            //Fill array using for loop
            for (int i = 0; i < 12; i++)
            {
                months[i] = dtInfo.MonthNames[i];
            }
            //Display all months
            Console.WriteLine("Months of the year: ");
            foreach (string month in months)
            {
                Console.WriteLine(month);
            }


            //Part5 Solving Quadratic Equations

            Console.WriteLine("Input a");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input b");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input c");
            int c = Convert.ToInt32(Console.ReadLine());

            quadratic(a, b, c);
        }
        public static void quadratic(int a, int b, int c)
        {
            int delta = (b * b) - 4 * a * c;


            if (delta > 0)
            {
                Console.WriteLine("Two real roots: ");
                Console.WriteLine("x1= " + (-b + Math.Sqrt(delta)) / 2 * a);
                Console.WriteLine("x2= " + (-b - Math.Sqrt(delta)) / 2 * a);
            }
            else if (delta == 0)
            {
                
                Console.WriteLine("One real root: "+ -b/2*a);
            }
            else
            {
                Console.WriteLine("Complex roots");
            }


        }
    }
}
