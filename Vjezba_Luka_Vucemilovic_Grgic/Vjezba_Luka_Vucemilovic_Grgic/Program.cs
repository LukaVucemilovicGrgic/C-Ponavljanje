using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_Luka_Vucemilovic_Grgic
{
    internal class Program
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
                        break;
                    case 7:
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
