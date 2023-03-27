using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_Luka_Vucemilovic_Grgic
{
    class Program : Methods
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose one of the 8 options.");
            Console.WriteLine("1-Parity");
            Console.WriteLine("2-Square Unity");
            Console.WriteLine("3-Average");
            Console.WriteLine("4-Digits");
            Console.WriteLine("5-Lotto");
            Console.WriteLine("6-Lottery Ticket");
            Console.WriteLine("7-Person");
            Console.WriteLine("8-PDF");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6 || choice == 7 || choice == 8)
            {
                switch (choice)
                {
                    case 1:

                        int number = Convert.ToInt32(Console.ReadLine());
                        if (number < 0)
                        {
                            Console.WriteLine("Incorrect entry, the number must be positive");
                        }
                        else if (number % 2 == 0)
                        {
                            Console.WriteLine("The number is even.");
                        }
                        else
                        {
                            Console.WriteLine("The number is odd");
                        }
                        break;

                    case 2:

                        Console.Write("Enter coefficient a: ");
                        double a = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter coefficient b: ");
                        double b = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter coefficient c: ");
                        double c = Convert.ToDouble(Console.ReadLine());

                        double diskriminanta = b * b - 4 * a * c;

                        if (diskriminanta < 0)
                        {
                            Console.WriteLine("The equation has no realistic solutions, because number under root is less than 0.");
                        }
                        else if (diskriminanta == 0)
                        {
                            double x = -b / (2 * a);
                            Console.WriteLine("The equation has one solution: x = {0}", x);
                        }
                        else
                        {
                            double x1 = (-b + Math.Sqrt(diskriminanta)) / (2 * a);
                            double x2 = (-b - Math.Sqrt(diskriminanta)) / (2 * a);
                            Console.WriteLine("The equation has two solutions:: x1 = {0} i x2 = {1}", x1, x2);
                        }
                        break;

                    case 3:

                        int brojOcjena = 0;
                        int zbrojOcjena = 0;
                        int ocjena;
                        double prosjek;


                        Console.Write("Type a grade (or 0 for the end of the entry): ");
                        while (true)
                        {
                            Console.Write("Grade: ");
                            if (!int.TryParse(Console.ReadLine(), out ocjena))
                            {
                                Console.WriteLine("Invalid entry. The grade must be a whole number.");
                                continue;
                            }

                            if (ocjena == 0)
                            {
                                break;
                            }

                            if (ocjena < 1 || ocjena > 5)
                            {
                                Console.WriteLine("Invalid entry. The grade must be between 1 and 5.");
                                continue;
                            }

                            brojOcjena++;
                            zbrojOcjena += ocjena;
                        }

                        if (brojOcjena > 0)
                        {
                            prosjek = (double)zbrojOcjena / brojOcjena;
                            if (prosjek >= 4.5)
                            {
                                Console.WriteLine("Excellent");
                            }
                            else if (prosjek >= 3.5)
                            {
                                Console.WriteLine("Very good");
                            }
                            else if (prosjek >= 2.5)
                            {
                                Console.WriteLine("Good");
                            }
                            else if (prosjek >= 1.5)
                            {
                                Console.WriteLine("Sufficient");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient");
                            }
                            Console.WriteLine("The average of the grades entered is {0}.", prosjek);
                        }
                        else
                        {
                            Console.WriteLine("No grades were entered.");
                        }

                        break;

                    case 4:

                        Console.WriteLine("Enter the number of numbers you want to input: ");
                        int count = int.Parse(Console.ReadLine());

                        List<int> numbers = new List<int>();
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine("Enter number #{0}: ", i + 1);
                            int inputNumber = int.Parse(Console.ReadLine());
                            numbers.Add(inputNumber);
                        }

                        int sum = 0;
                        foreach (int inputNumber in numbers)
                        {
                            sum += inputNumber % 10;
                        }

                        Console.WriteLine("The sum of the last digits of the entered numbers is: {0}", sum);

                        break;



                    case 5:

                        List<int> izvuceniBrojevi = new List<int>();
                        Random rand = new Random();

                        while (izvuceniBrojevi.Count < 7)
                        {
                            int broj = rand.Next(1, 46);

                            if (!izvuceniBrojevi.Contains(broj))
                            {
                                izvuceniBrojevi.Add(broj);
                            }
                        }

                        Console.WriteLine("The lotto's on its way, the lucky numbers are: ");
                        foreach (int broj in izvuceniBrojevi)
                        {
                            Console.Write("{0} ", broj);
                        }

                        break;

                    case 6:

                        // Naslov listića
                        Console.WriteLine("Loto 6 od 49 - Ticket");

                        // Generiranje brojeva u rasponu od 1 do 49
                        List<int> brojevi = new List<int>();
                        Random random = new Random();
                        while (brojevi.Count < 6)
                        {
                            int broj = random.Next(1, 50);
                            if (!brojevi.Contains(broj))
                            {
                                brojevi.Add(broj);
                            }
                        }
                        // Ispisivanje brojeva u matrici 7x7
                        int[,] matrica = new int[7, 7];
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                matrica[i, j] = i * 7 + j + 1;
                                Console.Write("{0,3}", matrica[i, j]);
                                /*Za i=0 i j=0, vrijednost i * 7 + j + 1 je 0 * 7 + 0 + 1 = 1,
                                 * što je prvi broj u matrici. Za i=1 i j=0, vrijednost je 1 * 7 + 0 + 1 = 8,
                                 * što je drugi redak u matrici i prvi stupac.*/
                            }

                            Console.WriteLine();
                        }
                        // Spremanje listića u .txt datoteku
                        string filePath = @"D:\LottoTicket.txt";
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            writer.WriteLine("Loto 6 od 49 - Ticket");
                            writer.WriteLine();
                            for (int i = 0; i < 7; i++)
                            {
                                for (int j = 0; j < 7; j++)
                                {
                                    writer.Write("{0,3}", matrica[i, j]);
                                }
                                writer.WriteLine();
                            }
                        }
                        Console.WriteLine("The ticket is saved to a file {0}.", filePath);

                        break;

                    case 7:

                        Console.WriteLine("Input 4 people (First Name, Last Name, Date of Birth (dd/mm/yyyy) and Sex (M/F)) ");
                        List<Person> persons = new List<Person>();

                        for (int i = 0; i < 4; i++)
                        {
                            Console.WriteLine("Enter person number {0}: ", i + 1);

                            Console.Write("First Name: ");
                            string firstName = Methods.ReadStringInput(50);

                            Console.Write("Last Name: ");
                            string lastName = Methods.ReadStringInput(50);

                            Console.Write("Date of Birth (dd/mm/yyyy): ");
                            DateTime dateOfBirth = Methods.ReadDateTimeInput(new DateTime(1900,1,1), new DateTime(2020,12,30) );

                            Console.Write("Sex (M/F): ");
                            string[] validInputs = new string[2] {"M", "F" };
                            string sex = Methods.ReadSexInput(validInputs);

                            persons.Add(new Person
                            {
                                firstName = firstName,
                                lastName = lastName,
                                dateOfBirth = dateOfBirth,
                                sex = sex
                            });
                        }

                        Statistics statistics = new Statistics
                        {
                            youngestPerson = FindYoungestPerson(persons),
                            oldestPerson = FindOldestPerson(persons),
                            numberOfMan = CountNumberOfMan(persons),
                            numberOfWoman = CountNumberOfWoman(persons),
                            numberOfPeopleBornBefore2000 = CountNumberOfPeopleBornBefore2000(persons)
                        };

                        Console.WriteLine("Statistics: ");
                        Console.WriteLine("Youngest person: {0}", statistics.youngestPerson);
                        Console.WriteLine("Oldest person: {0}", statistics.oldestPerson);
                        Console.WriteLine("Number of men: {0}", statistics.numberOfMan);
                        Console.WriteLine("Number of women: {0}", statistics.numberOfWoman);
                        Console.WriteLine("Number of people born before 2000: {0}", statistics.numberOfPeopleBornBefore2000);

                        Console.ReadLine();

                        break;

                    case 8:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong input, dial again between 1 and 8");
            }

            Console.ReadLine();
        }
    }
}
