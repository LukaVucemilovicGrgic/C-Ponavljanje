using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_Luka_Vucemilovic_Grgic
{
    public class Methods
    {
        public static string FindYoungestPerson(List<Person> persons)
        {
            DateTime minDate = DateTime.MaxValue;
            string youngestPerson = "";

            foreach (var person in persons)
            {
                if (person.dateOfBirth < minDate)
                {
                    minDate = person.dateOfBirth;
                    youngestPerson = person.firstName + " " + person.lastName;
                }
            }

            return youngestPerson;
        }

        public static string FindOldestPerson(List<Person> persons)
        {
            DateTime maxDate = DateTime.MinValue;
            string oldestPerson = "";

            foreach (var person in persons)
            {
                if (person.dateOfBirth > maxDate)
                {
                    maxDate = person.dateOfBirth;
                    oldestPerson = person.firstName + " " + person.lastName;
                }
            }

            return oldestPerson;
        }

        public static int CountNumberOfMan(List<Person> persons)
        {
            int count = 0;

            foreach (var person in persons)
            {
                if (person.sex.ToUpper() == "M")
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountNumberOfWoman(List<Person> persons)
        {
            int count = 0;

            foreach (var person in persons)
            {
                if (person.sex.ToUpper() == "F")
                {
                    count++;
                }
            }

            return count;
        }

        public static int CountNumberOfPeopleBornBefore2000(List<Person> persons)
        {
            int count = 0;

            foreach (var person in persons)
            {
                if (person.dateOfBirth.Year < 2000)
                {
                    count++;
                }
            }

            return count;
        }

        public static string ReadStringInput(int maxLength)
        {
            string input = Console.ReadLine();
            while (!IsStringInputValid(input) || input.Length > maxLength)
            {
                Console.WriteLine("Invalid input. Please enter only letters with a maximum length of {0}.", maxLength);
                input = Console.ReadLine();
            }
            return input;
        }


        public static bool IsStringInputValid(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static DateTime ReadDateTimeInput(DateTime minDate, DateTime maxDate)
        {

            DateTime dateOfBirth;
            string input = Console.ReadLine();
            while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateOfBirth)
                || dateOfBirth < minDate || dateOfBirth > maxDate)
            {
                Console.WriteLine($"Invalid input. Please enter a valid date in the format dd/mm/yyyy between {minDate.ToShortDateString()} and {maxDate.ToShortDateString()}.");
                input = Console.ReadLine();
            }
            return dateOfBirth;
        }

        public static string ReadSexInput(string[] validInputs)
        {
            string input = Console.ReadLine().ToUpper();
            while (!validInputs.Contains(input))
            {
                Console.WriteLine($"Invalid input. Please enter one of the following: {string.Join(", ", validInputs)}");
                input = Console.ReadLine().ToUpper();
            }
            return input;
        }

    }
}
