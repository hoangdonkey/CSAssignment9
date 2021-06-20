using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex1
            StudentManager management = new StudentManager();
            string confirmContinue;
            int choice = 0;
            Console.WriteLine("=====Student Management Program=====");
            do
            {
                Console.Write("Enter student's name: ");
                string studentName = Console.ReadLine();
                bool addSuccess = management.AcceptDetail(studentName);
                if (addSuccess)
                {
                    Console.Write("Do you want to add more names? [Y/N] : ");
                }
                else
                {
                    Console.WriteLine("Add failed!");
                    Console.WriteLine("Do you want to add another name ? [Y/N] : ");
                }
                confirmContinue = Console.ReadLine();
            } while (confirmContinue.ToUpper().Equals("Y"));
            management.DisplayDetail();
            do
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                switch (choice)
                {
                    case 1:
                        management.Sort();
                        Console.WriteLine("-----After Sorting-----");
                        management.DisplayDetail();
                        break;
                    case 2:
                        Console.Write("Enter name of the student : ");
                        string removingName = Console.ReadLine();
                        bool removeSuccess = management.Remove(removingName);
                        if (removeSuccess)
                        {
                            Console.WriteLine("-----After Removing-----");
                            management.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine("Remove failed!. Cannot find the student whose name is : " + removingName);
                        }
                        break;
                    case 3:
                        management.Reverse();
                        Console.WriteLine("-----After Reversing-----");
                        management.DisplayDetail();
                        break;
                    case 4:
                        Console.Write("Enter student name: ");
                        string searchName = Console.ReadLine();
                        bool find = management.Search(searchName);
                        if (!find)
                        {
                            Console.WriteLine("Cannot find the student whose name is : " + searchName);
                        }
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again!");
                        break;
                }
            } while (choice != 5);
            Console.WriteLine("\nProgram ENDED!");

            static void DisplayMenu()
            {
                Console.WriteLine("Select one of the following options: ");
                Console.WriteLine("1. Sort");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Reverse");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Exit");
            }

            //Ex2
            Console.WriteLine("=====Student Management Program=====");
            do
            {
                try
                {
                    Console.WriteLine("Enter student's roll number (10 characters) : ");
                    string rollNumber = Console.ReadLine();
                    if (rollNumber.Length != 10)
                    {
                        throw new ArgumentException("Student RollNumer must have exactly 10 characters!");
                    }
                    Console.Write("Enter student's name: ");
                    string studentName = Console.ReadLine();
                    bool addSuccess = management.AcceptDetail(rollNumber, studentName);
                    if (addSuccess)
                    {
                        Console.Write("Do you want to add more records? [Y/N] : ");
                    }
                    else
                    {
                        Console.WriteLine("Do you want to add another records ? [Y/N] : ");
                    }
                    confirmContinue = Console.ReadLine();
                    if (!confirmContinue.ToUpper().Equals("Y"))
                    {
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
            management.DisplayDetail();
            do
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter roll number of the student : ");
                        string removingRollNumber = Console.ReadLine();
                        bool removeSuccess = management.Remove(removingRollNumber);
                        if (removeSuccess)
                        {
                            Console.WriteLine("-----After Removing-----");
                            management.DisplayDetail();
                        }
                        else
                        {
                            Console.WriteLine("Remove failed!. Cannot find the student whose rollNumber is : " + removingRollNumber);
                        }
                        break;
                    case 2:
                        management.RemoveAll();
                        Console.WriteLine("=====After removing All=====");
                        management.DisplayDetail();
                        break;
                    case 3:
                        Console.Write("Enter student Roll Number: ");
                        string searchRollNumber = Console.ReadLine();
                        bool find = management.Search(searchRollNumber);
                        if (!find)
                        {
                            Console.WriteLine("Cannot find the student whose roll number is : " + searchRollNumber);
                        }
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again!");
                        break;
                }
            } while (choice != 4);

            Console.WriteLine("Program ENDED!");
            Console.ReadKey();
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Select one of the following options: ");
            Console.WriteLine("1. Remove");
            Console.WriteLine("2. Remove All");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Exit");
        }
    }
}


