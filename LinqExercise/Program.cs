using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum;{sum}");
            //DONE: Print the Average of numbers
            var avg = numbers.Average();
            Console.WriteLine($"The Average:{avg}");
            //DONE: Order numbers in ascending order and print to the console
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("---------------------");
            Console.WriteLine($"Numbers in order:");
            foreach(var num in asc)
            {
                Console.WriteLine(num);
            }
            //DONE: Order numbers in decsending order and print to the console
            Console.WriteLine("-----------------------");
            var dec = numbers.OrderByDescending(num => num);
            Console.WriteLine($"Numbers going backwards:");
            foreach(var num in dec)
            {
                Console.WriteLine(num);
            }
            //DONE: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6 numbers:");
            var greaterthan = numbers.Where(x => x > 6);
            foreach(var item in greaterthan)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------");

            }
            //DONE: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            
            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("First 4 in ascending order.");
            Console.WriteLine("---------------------------");

            //DONE: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Numbers descending with my age.");
            numbers[4] = 22;
            foreach (var item in numbers.OrderByDescending  (num => num))
            {
                Console.WriteLine(item);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //DONE: Print all the employees' FullName properties to the console only if their FirstName starts with a C or an S.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);

            foreach(var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            //TODO:int all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overtwentysix = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);

            Console.WriteLine("Over 26");
            foreach(var employee in overtwentysix)
            {
                Console.WriteLine($"Full Name:{employee.FullName} Age: {employee.Age}");
            }
            //DONE: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumofYOE = employees.Sum(emp => emp.YearsOfExperience);
            var avgYOE = employees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum: {sumofYOE} Avg: {avgYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("first name", "last name", 45, 2)).ToList();

            foreach(var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
