using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuTutorial2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("--------------Calculator---------------");
                Console.WriteLine("1.Square root calculator");
                Console.WriteLine("2.Array operations");
                Console.WriteLine("3.Month name lookup");
                Console.WriteLine("4.Quadratic equation solver");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Input your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) {
                    case 1:
                        Console.WriteLine("Square root calculator");
                        int number;
                        Console.WriteLine("Input a number to square root");
                        number = Convert.ToInt32(Console.ReadLine());

                        if (number > 0)
                            Console.WriteLine(number + " has a square root is: " + Math.Sqrt(number));
                        else
                            Console.WriteLine("Please input number greater than 0!");
                        break;
                    case 2:
                        Console.WriteLine("Array operations");
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
                        break;
                    case 3:
                        Console.WriteLine("Month name lookup");
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
                        break;
                    case 4:
                        Console.WriteLine("Quadratic equation solver");
                        Console.WriteLine("Input a");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input b");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Input c");
                        int c = Convert.ToInt32(Console.ReadLine());

                        int delta = (b * b) - 4 * a * c;


                        if (delta > 0)
                        {
                            Console.WriteLine("Two real roots: ");
                            Console.WriteLine("x1= " + (-b + Math.Sqrt(delta)) / 2 * a);
                            Console.WriteLine("x2= " + (-b - Math.Sqrt(delta)) / 2 * a);
                        }
                        else if (delta == 0)
                        {

                            Console.WriteLine("One real root: " + -b / 2 * a);
                        }
                        else
                        {
                            Console.WriteLine("Complex roots");
                        }
                        break;
                    case 5:
                        Console.WriteLine("exiting......");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

            }
        }
    }
}
