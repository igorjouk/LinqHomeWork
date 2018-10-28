using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person("Ivan", 31, "Male", 400),
                new Person("Zhenja", 24, "Male", 21000),
                new Person("Dasha", 22, "Female", 570),
                new Person("Lesha", 25, "Male", 14758),
                new Person("Sonja", 27, "Female", 4792)
            };

            // 1)

            // The oldest
            // Option 1
            var theOldestName1 = persons
                .Where(p => p.Age == persons.Select(per => per.Age).Max())
                .FirstOrDefault()
                .Name;

            // The oldest
            // Option 2
            var theOldestName2 = persons.OrderByDescending(p => p.Age)
                .FirstOrDefault()
                .Name;

            Console.WriteLine($"The oldest person(option 1): {theOldestName1}");
            Console.WriteLine($"The oldest person(option 2): {theOldestName2}");
            Console.WriteLine();

            //----------------------------------------------------------------------

            // The richest
            // Option 1
            var theRichestName1 = persons
                .Where(p => p.Balance == persons.Select(per => per.Balance).Max())
                .FirstOrDefault()
                .Name;

            // The rihest
            // Option 2
            var theRichestName2 = persons.OrderByDescending(p => p.Balance)
                .FirstOrDefault()
                .Name;

            Console.WriteLine($"The richest person(option 1): {theRichestName1}");
            Console.WriteLine($"The richest person(option 2): {theRichestName2}");
            Console.WriteLine();

            //----------------------------------------------------------------------

            // The richest and the oldest???
            var theRichestAndTheOldest = persons
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Balance)
                .FirstOrDefault()
                .Name;

            Console.WriteLine($"The richest and the oldest person: {theRichestAndTheOldest}");
            Console.WriteLine();


            // 2)
            // Greater than 4000

            var personsCount = persons.Where(p => p.Balance > 4000).Count();
            Console.WriteLine($"Number of persons with balance more than 4000: {personsCount}");
            Console.WriteLine();

            // 3)
            // Sort by age
            var sortByAge = persons.OrderBy(p => p.Age);
            Console.WriteLine("Sorted by age");
            foreach (var item in sortByAge)
            {
                Console.WriteLine($"Name: {item.Name} Age:{item.Age} Sex:{item.Sex} Balance:{item.Balance}");
            }
            Console.WriteLine();


            // Sort by sex
            var sortBySex = persons.OrderBy(p => p.Sex);
            Console.WriteLine("Sorted by sex");
            foreach (var item in sortBySex)
            {
                Console.WriteLine($"Name: {item.Name} Age:{item.Age} Sex:{item.Sex} Balance:{item.Balance}");
            }
            Console.WriteLine();

            // Sort by balance
            var sortByBalance = persons.OrderBy(p => p.Balance);
            Console.WriteLine("Sorted by balance");
            foreach (var item in sortByBalance)
            {
                Console.WriteLine($"Name: {item.Name} Age:{item.Age} Sex:{item.Sex} Balance:{item.Balance}");
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Sex { get; set; }
        public int Balance { get; set; }

        public Person(string name, byte age, string sex, int balance)
        {
            Name = name;
            Age = age;
            Sex = sex;
            Balance = balance;

        }
    }
}
