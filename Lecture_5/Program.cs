using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_5
{
    public enum Seasons
    {
        Spring,
        Summer, 
        Autumn,
        Winter
    }
    public enum UserRoles
    {
        Admin,
        Editor,
        Viewer
    }
    class Box<T>
    {
        private T content;
        public Box(T content)
        {
            this.content = content;
        }

        public T getContent()
        {
            return this.content;
        }
    }
    class Animal
    {
        private string name;
        public string getName()
        {
            return this.name;
        }
        public void setAnimal(string name)
        {
            this.name = name;
        }

    }
    class Dog : Animal
    {
        private string color;
        public Dog(string name, string color) : base(name)
        {
            this.color = color;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Seasons
            Seasons MySeason;
            MySeason = Seasons.Spring;
            Console.WriteLine(MySeason);
            MySeason = (Seasons)1;
            Console.WriteLine(MySeason);
            
            //UserRoles
            UserRoles MyUserRoles;
            MyUserRoles = (UserRoles)0;
            Console.WriteLine(MyUserRoles);
            MyUserRoles = (UserRoles)1;
            Console.WriteLine(MyUserRoles);
            MyUserRoles = (UserRoles)2;
            Console.WriteLine(MyUserRoles);
            //
            Box<int> boxInt = new Box<int>(2025);
            Console.WriteLine(boxInt.getContent());

            // Arrays of object
            Animal[] animals = new Animal[10];
            foreach(Animal i in animals) {
                Console.WriteLine(animals);
            }
            
        }
    }
}
