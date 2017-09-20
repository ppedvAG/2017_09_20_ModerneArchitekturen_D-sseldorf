using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    internal delegate bool MyDelegate(Employee e);
    // Action       -> void
    // Predicate    -> bool
    // Func


    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedingung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedingung);
            //var del = new Func<Employee, bool>(Bedingung);
            //Func<Employee, bool> del = Bedingung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedingung);

            //var query = Abfrage(employees, delegate (Employee e)
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (Employee e) =>
            //{
            //    return e.Name.Length > 3;
            //});

            //var query = Abfrage(employees, (e) => e.Name.Length > 3);
            //var query = Abfrage(employees, e => e.Name.Length > 3);
            var query = employees.Abfrage(e => e.Name.Length > 3);
            var queryLinq = employees.Where(Bedingung);

            var namen = new[] { "Hans", "Peter", "Max" };
            var namenLänger3Buchstaben = namen.Abfrage(n => n.Length > 3);

            foreach (var e in query)
                Console.WriteLine($"ID: {e.Id,2} | {e.Name,-10} | {e.Experience,2}");

            Console.ReadKey();
        }

        private static bool Bedingung(Employee e)
        {
            return e.Name.StartsWith("A");
        }

        private static IEnumerable<Employee> Abfrage(
            IEnumerable<Employee> employees, 
            Func<Employee, bool> predicate)
        {
            foreach (var e in employees)
                if (predicate(e))
                    yield return e;
        }

        private static IEnumerable<Employee> GetData()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Max", Experience = 8 },
                new Employee { Id = 2, Name = "Lisa", Experience = 1 },
                new Employee { Id = 3, Name = "Andreas", Experience = 5 },
                new Employee { Id = 4, Name = "Luis", Experience = 11 },
                new Employee { Id = 5, Name = "Stanislaus", Experience = 7 },
                new Employee { Id = 6, Name = "Maria", Experience = 9 },
                new Employee { Id = 7, Name = "Alexa", Experience = 2 },
                new Employee { Id = 8, Name = "Siri", Experience = 6 },
                new Employee { Id = 9, Name = "Cortana", Experience = 7 }
            };
        }
    }

    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> Abfrage<T>(
            this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (var e in source)
                if (predicate(e))
                    yield return e;
        }
    }
}
