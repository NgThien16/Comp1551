using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4
{
    class Vehicle
    {
        private int year;

        // properties
       public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public Vehicle() {
            Console.WriteLine("Create a vehicle without parameters");
        }
        public Vehicle(int year)
        {
            this.year = year;
            Console.WriteLine("Create a vehicle with parameters");
        }
        //function
        public void Say()
        {
            Console.WriteLine("Vehicle");
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Year:{year}");
        }
    }
    class Car : Vehicle
    {
        private string color;
        public Car() {
       
            
            Console.WriteLine("Create a car without parameters");
        }
        public Car(int year, string color): base(year)
        {
            this.color = color;
            Console.WriteLine("Create a car with parameters");
        }

       
        public new void Say()
        {      
            Console.WriteLine("This is Car");
        }
        public new void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Color:{color}");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(2000);    
            vehicle.Say();
            vehicle.DisplayInfo();

            Car car = new Car(2025, "Blue");
            car.Say();
            car.DisplayInfo();
        }
    }
}
