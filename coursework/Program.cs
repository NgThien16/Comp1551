using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace coursework
{
    public enum Role
    {
        Teacher,
        Student, 
        Admin
    }
    internal class Program
    { 
            private static void MainMenu()
            {
                EducationCentreSystem educationCentre = new EducationCentreSystem();
                bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("\n----------EDUCATION SYSTEM------------");
                    Console.WriteLine("1. Teaching Staff Management");
                    Console.WriteLine("2. Student Management");
                    Console.WriteLine("3. Administration Management");
                    Console.WriteLine("4. Display all");
                    Console.WriteLine("5. Exit");
                    Console.Write("Please choose from 1–5: ");

                    string userChoice = Console.ReadLine();
                    Console.WriteLine($"User has chosen: {userChoice}");

                    switch (userChoice)
                    {
                        case "1":// Teacher menu
                            TeacherMenu();
                            break;
                        case "2":// student menu
                            StudentMenu();
                            break;
                        case "3":// admin menu
                            AdminMenu();
                            break;
                        case "4":
                            educationCentre.DisplayAll();
                            break;
                        case "5":
                            isRunning = false;
                            Console.WriteLine("Exiting..........");
                            break;
                        default:
                            Console.WriteLine("Please, choose from 1-4");
                            break;
                    }
                }
            }
            private static void TeacherMenu()
            {
                EducationCentreSystem educationCentreSystem = new EducationCentreSystem();
                bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("\n----------Teaching Staff Management-----------");
                    Console.WriteLine("1. Add new teacher");
                    Console.WriteLine("2. Display list teacher");
                    Console.WriteLine("3. Delete teacher");
                    Console.WriteLine("4. Edit teacher");
                    Console.WriteLine("5. Exit");
                    Console.Write("Please choose from 1–5: ");

                    string userChoice = Console.ReadLine();
                    Console.WriteLine($"User has chosen: {userChoice}");

                    switch (userChoice)
                    {
                        case "1":
                            educationCentreSystem.Add(Role.Teacher);
                            break;
                        case "2":
                            educationCentreSystem.DisplayByRole(Role.Teacher);
                            break;
                        case "3":
                            educationCentreSystem.Delete(Role.Teacher);
                            break;
                        case "4":
                            educationCentreSystem.Update(Role.Teacher);
                            break;
                        case "5":
                            isRunning = false;
                            Console.WriteLine("Exiting..........");
                            break;
                        default:
                            Console.WriteLine("Please, choose from 1-5");
                            break;
                    }
                }
            }
            private static void StudentMenu()
            {
                EducationCentreSystem educationCentreSystem = new EducationCentreSystem();
                bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("\n----------Student Management-----------");
                    Console.WriteLine("1. Add new student");
                    Console.WriteLine("2. Display list student");
                    Console.WriteLine("3. Delete student");
                    Console.WriteLine("4. Edit student");
                    Console.WriteLine("5. Exit");
                    Console.Write("Please choose from 1–5: ");

                    string userChoice = Console.ReadLine();
                    Console.WriteLine($"User has chosen: {userChoice}");

                    switch (userChoice)
                    {
                        case "1":
                            educationCentreSystem.Add(Role.Student);
                            break;
                        case "2":
                            educationCentreSystem.DisplayByRole(Role.Student);
                            break;
                        case "3":
                            educationCentreSystem.Delete(Role.Student);
                            break;
                        case "4":
                            educationCentreSystem.Update(Role.Student);
                            break;
                        case "5":
                            isRunning = false;
                            Console.WriteLine("Exiting..........");
                            break;
                        default:
                            Console.WriteLine("Please, choose from 1-5");
                            break;
                    }
                }
            }
            private static void AdminMenu()
            {
                EducationCentreSystem educationCentreSystem = new EducationCentreSystem();
                bool isRunning = true;
                while (isRunning)
                {
                    Console.WriteLine("\n----------Administration Management-----------");
                    Console.WriteLine("1. Add new admin");
                    Console.WriteLine("2. Display list admin");
                    Console.WriteLine("3. Delete admin");
                    Console.WriteLine("4. Edit admin");
                    Console.WriteLine("5. Exit");
                    Console.Write("Please choose from 1–5: ");

                    string userChoice = Console.ReadLine();
                    Console.WriteLine($"User has chosen: {userChoice}");

                    switch (userChoice)
                    {
                        case "1":
                            educationCentreSystem.Add(Role.Admin);
                            break;
                        case "2":
                            educationCentreSystem.DisplayByRole(Role.Admin);
                            break;
                        case "3":
                            educationCentreSystem.Delete(Role.Admin);
                            break;
                        case "4":
                            educationCentreSystem.Update(Role.Admin);
                            break;
                        case "5":
                            isRunning = false;
                            Console.WriteLine("Exiting..........");
                            break;
                        default:
                            Console.WriteLine("Please, choose from 1-5");
                            break;
                    }
                    
                }
            }
            static void Main(string[] args)
            {
                MainMenu();

            }
        }
    }
