
namespace _01_HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Test
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Stefan", "Bratovanov", "85798579"),
                new Student("Is", "Pis", "05091978"),
                new Student("Alexander", "Ivanov", "0656d78"),
                new Student("Goran", "Goranov", "485dgb78"),
                new Student("Ivan", "Dunchev", "425684dff"),
                new Student("Rosen", "Nikolov", "84226ef"),
                new Student("Kosta", "Kostov", "6655fds6"),
                new Student("Boqn", "Asenov", "2241d55"),
                new Student("Vladimir", "Borislavov", "8545ede38"),
                new Student("Petyr", "Petrov", "84ds84s")
            };
            List<Worker> workers = new List<Worker>()
            {
               new Worker("Bolqr", "bolqr", 0, 0),
               new Worker("Isi", "Pisi", 1000, 5),
               new Worker("Jordan", "Halachev", 400, 8),
               new Worker("Miroslav", "Blagoev", 200, 8),
               new Worker("Daniel", "Florev", 400, 7),
               new Worker("Stanislav", "Blagoev", 200, 8),
               new Worker("Emil", "Bobev", 600, 8),
               new Worker("Samuil", "Petrov", 180, 8),
               new Worker("Atanas", "Kynchev", 1200, 12),
               new Worker("Georgi", "Gegev", 700, 8)
            };

            // First way to sort
            var sortedStudents = students.OrderBy(st => st.FacultyNumber);

            foreach (var s in sortedStudents)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();

            // Second way to sort
            workers.Sort((x, y) => y.MoneyPerHour().CompareTo(x.MoneyPerHour()));
            workers.ForEach(Console.WriteLine);
            Console.WriteLine();

            //Merged
            List<Human> mergedList = new List<Human>();
            mergedList.AddRange(students);
            mergedList.AddRange(workers);

            //var sortedAll = mergedList.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
            //foreach (var item in sortedAll)
            //{
            //     Console.WriteLine(item);
            //}

            var sortedByNames = mergedList
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName)
                .Select(h => h.FirstName + " " + h.LastName);

            Console.WriteLine(string.Join("\n", sortedByNames));
        }
    }
}
