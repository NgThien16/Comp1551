using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application1551
{
    internal class exercise1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input number");
            int num = int.Parse(Console.ReadLine());
            
            if(num > 0)
            {
                Console.WriteLine("The square root is" + Math.Sqrt(num));
            }
            else
            {
                Console.WriteLine("Wrong input");

            }
        }
    }
}
