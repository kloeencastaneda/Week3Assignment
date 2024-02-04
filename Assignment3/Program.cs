using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Template
{
    internal class Program
    {
        //Setting up the student class
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double GPA { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }

            public Student(int id, string name, double gpa, string address, int age)
            {
                Id = id;
                Name = name;
                GPA = gpa;
                Address = address;
                Age = age;
            }
          

            public override string ToString()
            {
                return $"ID: {Id}, name: {Name}, gpa: {GPA}, age: {Age}, address: {Address}";
            }

        }

        static List<Student> students = new List<Student>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            mainMenu();
        }
        static void mainMenu()
        {
            Console.WriteLine("1. Add student.");
            Console.WriteLine("2. Edit student by id.");
            Console.WriteLine("3. Delete student by id.");
            Console.WriteLine("4. Sort student by gpa.");
            Console.WriteLine("5. Sort student by name.");
            Console.WriteLine("6. Show student.");
            Console.WriteLine("0. Exit");


            Console.WriteLine("Your option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    EditStudent();
                    break;
                case 3:
                    DeleteStudent();
                    break;
                case 4:
                    SortStudentByGPA();
                    break;
                case 5:
                    SortStudentByName();
                    break;
                case 6:
                    ShowStudents();
                    break;
                case 7:
                    Console.WriteLine("Exiting the app!");
                    return;
                default:
                    Console.WriteLine("Please choose a valid number.");
                    break;
            }

            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            mainMenu();

        }


        //METHODS

        static void AddStudent()
        {
            Console.Write("Enter student name: "); //Add the student's name
            string name = Console.ReadLine();

            double gpa;
            bool validGpa = false;
            while (!validGpa)
            {
                Console.Write("Enter student GPA (valid range: 0.0-4.0): ");
                string gpaStr = Console.ReadLine();
                if (double.TryParse(gpaStr, out gpa) && gpa >= 0.0 && gpa <= 4.0)

                {
                    validGpa = true;
                }
                else
                {
                    Console.WriteLine("Invalid GPA. Please enter a value between 0.0 and 4.0.");

                }


                Console.Write("Enter student address: ");
                string address = Console.ReadLine();

                int age;
                bool validAge = false;
                while (!validAge)
                {
                    Console.Write("Enter student age: ");
                    string ageStr = Console.ReadLine();

                    if (int.TryParse(ageStr, out age) && age > 0)
                    {
                        validAge = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Please enter a valid number.");
                    }


                    students.Add(new Student(nextId, name, gpa, address, age));
                    nextId++;  //ID will increment with every student added
                    Console.WriteLine("Student added successfully!");
                }
            }
        }

        //Edit student
        static void EditStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found. Please add some students first.");
                return;
            }

            Console.Write("Enter the ID of the student to edit: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int index = students.FindIndex(s => s.Id == id);
            if (index == -1)
            {
                Console.WriteLine("Student with ID {0} not found.", id);
                return;
            }

            Console.Write("Enter new name (or press enter to keep the current name): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                students[index].Name = newName;
            }

            bool validGpa = false;
            double newGpa;
            while (!validGpa)
            {
                Console.Write("Enter new GPA (or press enter to keep the current GPA): ");
                string gpaString = Console.ReadLine();
                if (string.IsNullOrEmpty(gpaString))
                {
                    break; //Keep current GPA
                }
                else if (double.TryParse(gpaString, out newGpa) && newGpa >= 0.0 && newGpa <= 4.0)
                {
                    students[index].GPA = newGpa;

                    Console.WriteLine("Do you want to edit the student's address?");
                    string editAddress = Console.ReadLine().ToLower();
                    if (editAddress == "y") ;

                    {
                        Console.Write("Enter new address: ");
                        string newAddress = Console.ReadLine();
                        students[index].Address = newAddress;
                        Console.WriteLine("Address was updated successfully. :)");
                    }
                }
            }
        }


        //Delete student

        static void DeleteStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found. Please add some students.");
                return;
            }


            Console.Write("Enter ID of the student to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            int index = students.FindIndex(s => s.Id == id);
            if (index == -1)
            {
                Console.WriteLine("Student with ID {0} not found.", id);
                return;
            }

            Console.WriteLine("Are you sure you want to delete student {0} ({1})? (y/n): ", students[index], id);
            string confirm = Console.ReadLine().ToLower();
            if (confirm == "y")
            {
                students.RemoveAt(index);
                Console.WriteLine("Student deleted successfully!");
            }
            else
            {
                Console.WriteLine("Student deletion cancelled.");
            }
        }


        //Sort by GPA
        static void SortStudentByGPA()
        {
            students.Sort((s1, s2) => s2.GPA.CompareTo(s1.GPA)); // Descending order (highest GPA first)
            Console.WriteLine("Students sorted by GPA (highest to lowest):");
            ShowStudents();
        }


        //Sort by name
        static void SortStudentByName()
        {
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name)); // Ascending order (alphabetical)
            Console.WriteLine("Students sorted by name:");
            ShowStudents();
        }

        //Show students
        static void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
         


     
                






         