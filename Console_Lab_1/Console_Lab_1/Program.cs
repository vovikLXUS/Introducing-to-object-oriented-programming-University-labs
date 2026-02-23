/*
 * = Лабораторна робота №1 варіант 10 =
 * Створити консольний застосунок, який виконує наступні функції:
 * 1. Вивести на екран інформацію про себе (ПІБ, вік, курс, група, e-mail). Знайти довжини всіх висот трикутника, 
 *    заданого з клавіатури. Вивести результат на екран.
 * 2. За даними, введеними з консолі, визначити значення виразу: 
 *    x = a * ((a + b) / (a - b)^3)^1/3 + (1 + (sina)^1/2) / (1 + cosb).
 * 3. За даними, введеними з консолі, визначити значення функції: 
 *    f(x) = a * x^2 + b^2 * x, x < 0; f(x) = (x + a) / (x - b), x > 0; f(x) = a / b, x = 0, b != 0.
 * 4. Написати метод, який виводить на консоль прізвище та ініціали студента за введеним рейтинговим балом.
 * 5. Дано натуральне число n та дійсне число x. Обчислити суму ряду: 
 *    S = sum((-1)^i * x^(2 * i - 1) / (2 * i + 1), i=1..n).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab_1
{
    internal class Program
    {
        static void Greeting() 
        {
            Console.WriteLine("Datsyshyn Volodymyr, 18 years"
                + "\n1 course, group IPZ-13(06)"
                + "\nvovadatsyshyn@knu.ua");
        }
        static void LengthOfHeights() // Завдання 1
        {

            Console.WriteLine("\nThe task performs calculations of the heights of a triangle, given from the keyboard"
                + "\nEnter integer values for the sides a, b, and c: ");
            Console.Write("a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("c = ");
            double c = Convert.ToDouble(Console.ReadLine());
            
            double p = (a + b + c) / 2;
            // Формула Герона для обчислення площі трикутника за сторонами a, b і c
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            // Формула для обчислення висоти на кожну сторону трикутника
            double HeightOfA = 2 * s / a,
                   HeightOfB = 2 * s / b,
                   HeightOfC = 2 * s / c;

            Console.WriteLine("\n-The results-"
                + "\nHeight to side a = " + HeightOfA + "."
                + "\nHeight to side b = " + HeightOfB + "."
                + "\nHeight to side c = " + HeightOfC + ".");
        }
        static void ValueOfExpression() // Завдання 2
        {
            Console.WriteLine("\nThe function calculates the value of x:");
            Console.WriteLine("x = a * ((a + b) / (a - b)^3)^1/3 + (1 + (sina)^1/2) / (1 + cosb)");
            Console.WriteLine("Enter values for a and b:");
            Console.Write("a = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            int b = Convert.ToInt32(Console.ReadLine());

            double firstRatio = Math.Pow((a + b) / Math.Pow((a - b), 3), 1.0 / 3.0),
                secondRatio = ((1 + Math.Sqrt(Math.Sin(a))) / (1 + Math.Cos(b)));
            double x = a * firstRatio + secondRatio;

            Console.WriteLine("-The result of the calculation: x = " + x + ".");
        }
        static void FindX() // Завдання 3
        {
            Console.Write("\nThe function calculates the value of f(x):"
                + "\n\t| a * x^2 + b^2 * x , x < 0"
                + "\nf(x) =  | (x + a) / (x - b) , x > 0"
                + "\n\t| a / b ,             x = 0, b != 0");
            Console.WriteLine("\nEnter values for a, b, and x:");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
            double result = 0.0;

            if (x < 0)
            {
                result = (a * Math.Pow(x, 2)) + (Math.Pow(b, 2) * x);
            }
            else if (x > 0)
            {
                double numerator = x + a,
                    denominator = x - b;
                if (denominator == 0)
                {
                    Console.WriteLine("It's impossible to determine the value of function,"
                        + "\nbecause x - b = 0. Try again.");
                    FindX();
                }
                result = numerator / denominator;
            }
            else if (x == 0)
            {
                if (b != 0)
                    result = a / b;
            }
            else
            {
                // $ - це символ для інтерполяції рядків, який дозволяє вставляти значення змінних в { } безпосередньо в рядок.
                Console.WriteLine($"Fuction at f({x}) is undefined. Try again.");
                FindX();
            }
            Console.WriteLine($"-The value of function at x = {x}: f(x) = {result}.");
        }
        struct Student // Структура для зберігання інформації про студента та спрощення коду для задачі
        {
            public string Initials;
            public double Mark;
        }

        static void StudentsInitialsByMark() // Завдання 4
        {
            Student[] students =
            {
        new Student { Mark = 71.29, Initials = "Троцюк Н. Р." },
        new Student { Mark = 72.57, Initials = "Домантович М. І." },
        new Student { Mark = 72.57, Initials = "Домантович М. І." },
        new Student { Mark = 73.00, Initials = "Зварич В. В." },
        new Student { Mark = 73.71, Initials = "Кулик Е. І." },
        new Student { Mark = 74.14, Initials = "Мошаровський І. А. та Ковальський М. В." },
        new Student { Mark = 76.00, Initials = "Маленький С. С." },
        new Student { Mark = 76.14, Initials = "Бєлоглазов О. А." },
        new Student { Mark = 76.71, Initials = "Борис Є. С." },
        new Student { Mark = 78.29, Initials = "Канапін А. Р." },
        new Student { Mark = 78.71, Initials = "Колосов В. С." },
        new Student { Mark = 79.29, Initials = "Ковальчук С. М." },
        new Student { Mark = 80.14, Initials = "Любка М. Ю. та Ємець Д. А." },
        new Student { Mark = 80.43, Initials = "Голованенко І. В." },
        new Student { Mark = 80.57, Initials = "Кривенко А. Ю." },
        new Student { Mark = 80.71, Initials = "Горбенко С. В." },
        new Student { Mark = 81.29, Initials = "Гладун С. С." },
        new Student { Mark = 82.00, Initials = "Лисенко О. І." },
        new Student { Mark = 82.29, Initials = "Залєвський В. А." },
        new Student { Mark = 82.71, Initials = "Корнієць Р. О." },
        new Student { Mark = 83.50, Initials = "Невінський О. В." },
        new Student { Mark = 83.86, Initials = "Агапов О. О." },
        new Student { Mark = 84.43, Initials = "Пуш В. С." },
        new Student { Mark = 84.86, Initials = "Бурлай Н. В. та Бартківський Ю. В." },
        new Student { Mark = 85.00, Initials = "Василик В. С." },
        new Student { Mark = 85.14, Initials = "Головатий В. С." },
        new Student { Mark = 87.00, Initials = "Сивопляс М. В." },
        new Student { Mark = 87.29, Initials = "Пастух С. І." },
        new Student { Mark = 87.43, Initials = "Дацишин В. О." },
        new Student { Mark = 87.57, Initials = "Никитенко В. О. та Білик Д. О." },
        new Student { Mark = 88.29, Initials = "Полякова А. А." },
        new Student { Mark = 89.00, Initials = "Стукало Т. О." },
        new Student { Mark = 89.29, Initials = "Падалка П. В." },
        new Student { Mark = 89.43, Initials = "Обозов Я. П." },
        new Student { Mark = 89.57, Initials = "Аксьом М. О." },
        new Student { Mark = 89.71, Initials = "Стрикун А. М." },
        new Student { Mark = 90.29, Initials = "Куціль О. В." },
        new Student { Mark = 90.43, Initials = "Рудий А. А." },
        new Student { Mark = 90.86, Initials = "Будзановська М. О." },
        new Student { Mark = 91.00, Initials = "Степанченко М. В." },
        new Student { Mark = 92.14, Initials = "Радкевич Д. І. та Бєлоусов В. А." },
        new Student { Mark = 92.29, Initials = "Бобенко С. Р." },
        new Student { Mark = 92.71, Initials = "Фояк В. М." },
        new Student { Mark = 93.14, Initials = "Борисенко Т. Р." },
        new Student { Mark = 93.43, Initials = "Мисель Є. В." },
        new Student { Mark = 93.57, Initials = "Ліпін К. С." },
        new Student { Mark = 93.71, Initials = "Кравець М. А." },
        new Student { Mark = 94.14, Initials = "Шмаркатюк І. І." },
        new Student { Mark = 94.93, Initials = "Безверха А. А." },
        new Student { Mark = 95.14, Initials = "Більчук Н. С." },
        new Student { Mark = 96.43, Initials = "Сорока Г. В." },
        new Student { Mark = 97.43, Initials = "Грабовська О. С." },
        new Student { Mark = 98.00, Initials = "Тарасенко М. С." }
    };
            Console.Write("\nThe function determines the initials of the student by the entered rating score.");
            while (true)
            {
                Console.Write("\nEnter the rating score through a comma (71,29–98; 0 – exit): ");
                double mark = double.Parse(Console.ReadLine());

                if (mark == 0)
                    break;

                bool found = false;
                for (int i = 0; i < students.Length; i++)
                {
                    if (Math.Abs(students[i].Mark - mark) < 0.01)
                    {
                        Console.WriteLine($"The student's initials at {mark} is: {students[i].Initials}");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"The score {mark} is not present in the ranking list.");
                }
            }
        }
        
        static void SumOfRow() // Завдання 5
        {
            Console.Write("\nThe function is calculating the sum of the series:");
            Console.Write("\n\t n  (-1)^i * x^(2 * i - 1)");
            Console.Write("\nS=      sum ----------------------");
            Console.Write("\n\ti=1      (2 * i + 1)");
            Console.Write("\nEnter a natural number for n (>0): ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
            {
                Console.WriteLine("Incorrect value specified for n. It must be > 0.");
                return;
            }

            Console.Write("Enter a real number through a comma for x > 0: ");
            double x;
            bool isDouble = double.TryParse(Console.ReadLine(), out x);
            if (x <= 0)
            {
                Console.WriteLine("Incorrect value specified for x.");
                return;
            }

            double sum = 0.0;
            for (int i = 1; i <= n; i++)
            {
                double numerator = Math.Pow(-1, i) * Math.Pow(x, 2 * i - 1),
                    denominator = 2 * i + 1;
                sum += numerator / denominator;
            }
            Console.WriteLine($"The sum of series at n = {n} and x = {x}: S = {sum}.");
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Greeting();

            int choice;
            do
            {
                Console.Write("\n=User's menu=\n"
                + "1. To calculate the heights of a triangle\n"
                + "2. To determine the value of the expression\n"
                + "3. To determine the value of the function\n"
                + "4. To determine the initials of a student by their rating score\n"
                + "5. To calculate the sum of the series\n"
                + "0. Exit\n"
                + "Your choice: ");
                choice = int.Parse(Console.ReadLine()); 

                switch (choice)
                {
                    case 1:
                        LengthOfHeights();
                        break;
                    case 2:
                        ValueOfExpression();
                        break;
                    case 3:
                        FindX();
                        break;
                    case 4:
                        StudentsInitialsByMark();
                        break;
                    case 5:
                        SumOfRow();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 0);
        }
    }
}