using System;
using System.Text;

namespace Console_Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Greet();

            int choice;
            int[] numbers = null;
            int[] sortedNumbers = null;
            int[,] matrix = null;
            bool isDigit;

            do
            {
                Console.Write("\n=========================== USER MENU ==========================="
                        + "\n1. Generate and sort a 1D array (Selection Sort)."
                        + "\n2. Find odd prime numbers (Sieve of Eratosthenes)."
                        + "\n3. Rearrange array elements by given conditions."
                        + "\n4. Find pentagonal numbers (Linear search)."
                        + "\n5. Find all occurrences of an element (Binary search)."
                        + "\n6. Generate and analyze a matrix of disciplines and competencies."
                        + "\n7. Sort matrix columns by the sum of their elements."
                        + "\n8. Find the roots of a non-linear equation (Bisection method)."
                        + "\n9. String manipulation (even-length words and removing brackets)."
                        + "\n0. Exit program."
                        + "\n================================================================="
                        + "\nYour choice: ");

                isDigit = int.TryParse(Console.ReadLine(), out choice);
                if (!isDigit)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Task1_GenerateAndSortArray(out numbers, out sortedNumbers);
                        break;
                    case 2:
                        if (numbers == null)
                        {
                            Console.WriteLine("Please complete Task 1 first!");
                            break;
                        }
                        Task2_FindOddPrimes(numbers);
                        break;
                    case 3:
                        if (numbers == null)
                        {
                            Console.WriteLine("Please complete Task 1 first!");
                            break;
                        }
                        Task3_RearrangeArray(numbers);
                        break;
                    case 4:
                        if (numbers == null)
                        {
                            Console.WriteLine("Please complete Task 1 first!");
                            break;
                        }
                        Task4_FindPentagonalNumbers(numbers);
                        break;
                    case 5:
                        if (sortedNumbers == null)
                        {
                            Console.WriteLine("Please complete Task 1 first!");
                            break;
                        }
                        Task5_BinarySearchAll(sortedNumbers);
                        break;
                    case 6:
                        Task6_GenerateAndAnalyzeMatrix(out matrix);
                        break;
                    case 7:
                        if (matrix == null)
                        {
                            Console.WriteLine("Please complete Task 6 first!");
                            break;
                        }
                        Task7_SortMatrixColumns(matrix);
                        break;
                    case 8:
                        Task8_BisectionMethod();
                        break;
                    case 9:
                        Task9_StringManipulation();
                        break;
                    case 0:
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again!");
                        break;
                }
            } while (choice != 0);
        }

        /// <summary>
        /// Виводить інформацію про розробника.
        /// </summary>
        static void Greet()
        {
            Console.WriteLine("Datsyshyn Volodymyr, 18 years");
            Console.WriteLine("1 course, group IPZ-13(06)");
            Console.WriteLine("vovadatsyshyn@knu.ua");
            Console.WriteLine("Introduction to Object-Oriented Programming.");
        }

        /// <summary>
        /// Запитує у користувача ціле число, поки не буде введено коректне значення.
        /// </summary>
        /// <param name="prompt">Текст-підказка для користувача.</param>
        /// <returns>Коректне ціле число.</returns>
        static int GetValidInt(string prompt)
        {
            int result;

            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid integer.");
                Console.Write(prompt);
            }
            return result;
        }

        /// <summary>
        /// Запитує у користувача дійсне число (з рухомою комою), поки не буде введено коректне значення.
        /// </summary>
        /// <param name="prompt">Текст користувача.</param>
        /// <returns>Коректне дійсне число типу double.</returns>
        static double GetValidDouble(string prompt)
        {
            double result;

            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid real number.");
                Console.Write(prompt);
            }
            return result;
        }

        /// <summary>
        /// Генерує масив випадкових чисел та сортує його копію за алгоритмом "Сортування вибором".
        /// </summary>
        /// <param name="originalArray">Повертає згенерований початковий масив.</param>
        /// <param name="sortedArray">Повертає відсортовану копію масиву.</param>
        static void Task1_GenerateAndSortArray(out int[] originalArray, out int[] sortedArray)
        {
            Console.WriteLine("\n- Generate and sort array -");

            int size = GetValidInt("Enter the number of array elements: ");
            while (size <= 0)
            {
                Console.WriteLine("Error: array size must be greater than 0.");
                size = GetValidInt("Enter the number of array elements: ");
            }

            int min = GetValidInt("Enter the minimum value: ");
            int max = GetValidInt("Enter the maximum value: ");

            while (max < min)
            {
                Console.WriteLine("Error: maximum value cannot be less than the minimum.");
                max = GetValidInt("Enter the maximum value: ");
            }

            originalArray = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                originalArray[i] = random.Next(min, max + 1);
            }

            Console.Write("\nGenerated array before sorting: ");
            PrintArray(originalArray);

            // Створюємо копію для сортування, щоб не змінювати оригінальний масив
            sortedArray = new int[size];
            Array.Copy(originalArray, sortedArray, size);

            // На кожній ітерації знаходимо найменший елемент у невідсортованій частині масиву
            // і міняємо його місцями з першим елементом цієї невідсортованої частини.
            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                int minIndex = i; // Припускаємо, що поточний елемент найменший
                for (int j = i + 1; j < sortedArray.Length; j++)
                {
                    if (sortedArray[j] < sortedArray[minIndex])
                    {
                        minIndex = j; // Знаходимо індекс дійсного найменшого елемента
                    }
                }

                // Якщо найменший елемент не на своєму місці - обмін 
                int temp = sortedArray[minIndex];
                sortedArray[minIndex] = sortedArray[i];
                sortedArray[i] = temp;
            }

            Console.Write("Array after Selection Sort (ascending): ");
            PrintArray(sortedArray);
        }

        /// <summary>
        /// Знаходить непарні прості числа у масиві за допомогою алгоритму "Решето Ератосфена".
        /// </summary>
        /// <param name="array">Вхідний масив чисел.</param>
        static void Task2_FindOddPrimes(int[] array)
        {
            Console.WriteLine("\n- Odd prime numbers (Sieve of Eratosthenes) -");

            // Знаходимо максимальне значення у масиві для побудови решета
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            if (max < 2)
            {
                Console.WriteLine("The array has no numbers sufficient for finding primes (no numbers >= 2).");
                return;
            }

            // Алгоритм "решето Ератосфена"
            // Створюємо логічний масив, де індекс = число. Значення true означає, що число просте.
            bool[] isPrime = new bool[max + 1];
            for (int i = 2; i <= max; i++)
                isPrime[i] = true;

            // Викреслюємо (встановлюємо false) всі числа, кратні поточним простим числам
            for (int p = 2; p * p <= max; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= max; i += p)
                        isPrime[i] = false;
                }
            }

            bool found = false;
            Console.Write("Found odd prime numbers: ");
            // Проходимо по нашому початковому масиву і перевіряємо кожне число за допомогою готового решета
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                // Перевіряємо, чи число більше 2 (бо 2 - парне), чи воно непарне, і чи воно просте
                if (num > 2 && num % 2 != 0 && isPrime[num])
                {
                    Console.Write(num + " ");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("None.");
            else
                Console.WriteLine();
        }

        /// <summary>
        /// Переставляє елементи масиву за спеціальними правилами (прості, складені з певними дільниками).
        /// </summary>
        /// <param name="array">Оригінальний масив чисел.</param>
        static void Task3_RearrangeArray(int[] array)
        {
            Console.WriteLine("\n- Rearrange array elements -");

            int[] result = new int[array.Length];
            int index = 0; // Вказівник поточної вільної позиції у масиві result

            // Проходимо по масиву кілька разів, щоб розмістити елементи у потрібному порядку
            // Спочатку записуємо всі прості числа
            for (int i = 0; i < array.Length; i++)
                if (IsPrime(array[i]))
                    result[index++] = array[i];

            // Складені, що діляться на 2, але не діляться на 3
            for (int i = 0; i < array.Length; i++)
                if (!IsPrime(array[i]) && array[i] % 2 == 0 && array[i] % 3 != 0)
                    result[index++] = array[i];

            // Складені, що діляться на 2 і на 3 (або ж на 6)
            for (int i = 0; i < array.Length; i++)
                if (!IsPrime(array[i]) && array[i] % 2 == 0 && array[i] % 3 == 0)
                    result[index++] = array[i];

            // Складені, що діляться тільки на 3 (та не діляться на 2)
            for (int i = 0; i < array.Length; i++)
                if (!IsPrime(array[i]) && array[i] % 3 == 0 && array[i] % 2 != 0)
                    result[index++] = array[i];

            // Всі інші числа, які не підпали під жодну з попередніх умов
            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                bool isPrime = IsPrime(num);
                bool isDiv2Not3 = !isPrime && num % 2 == 0 && num % 3 != 0;
                bool isDiv2And3 = !isPrime && num % 2 == 0 && num % 3 == 0;
                bool isDiv3Not2 = !isPrime && num % 3 == 0 && num % 2 != 0;

                if (!isPrime && !isDiv2Not3 && !isDiv2And3 && !isDiv3Not2)
                {
                    result[index++] = num;
                }
            }
            Console.Write("Array after rearrangement by groups: ");
            PrintArray(result);
        }

        /// <summary>
        /// Допоміжний метод для перевірки, чи є число простим.
        /// </summary>
        /// <param name="number">Число для перевірки.</param>
        /// <returns>True, якщо просте, інакше - False.</returns>
        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            // Перевіряємо дільники лише до квадратного кореня числа для оптимізації
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Лінійний пошук п'ятикутних чисел у масиві.
        /// П'ятикутне число обчислюється за формулою n(3n-1)/2.
        /// </summary>
        /// <param name="array">Вхідний масив.</param>
        static void Task4_FindPentagonalNumbers(int[] array)
        {
            Console.WriteLine("\n- Find pentagonal numbers -");
            bool found = false;

            for (int i = 0; i < array.Length; i++)
            {
                int x = array[i];
                if (x > 0)
                {
                    // Для перевірки чи число x є п'ятикутним, розв'язуємо квадратне рівняння.
                    // Зворотна формула: n = (sqrt(24x + 1) + 1) / 6
                    double n = (Math.Sqrt(24.0 * x + 1) + 1) / 6.0;

                    // Якщо отримане 'n' є цілим числом, то 'x' — це п'ятикутне число.
                    if (n == Math.Floor(n))
                    {
                        Console.WriteLine($"Found pentagonal number: {x} (Index: {i}, n = {n})");
                        found = true;
                    }
                }
            }

            if (!found) Console.WriteLine("No pentagonal numbers found in the array.");
        }

        /// <summary>
        /// Бінарний пошук всіх входжень елемента у відсортованому масиві.
        /// </summary>
        /// <param name="sortedArray">Відсортований масив.</param>
        static void Task5_BinarySearchAll(int[] sortedArray)
        {
            Console.WriteLine("\n- Binary search for an element -");

            int target = GetValidInt("Enter a number to search for: ");

            // Бінарний пошук
            int left = 0, right = sortedArray.Length - 1;
            int foundIndex = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Знаходимо середину масиву
                if (sortedArray[mid] == target)
                {
                    foundIndex = mid; // Елемент знайдено
                    break;
                }
                else if (sortedArray[mid] < target)
                    left = mid + 1; // Шукаємо у правій половині
                else
                    right = mid - 1; // Шукаємо у лівій половині
            }

            // Масив може містити повтори, шукаємо межі однакових елементів вліво і вправо
            if (foundIndex != -1)
            {
                int start = foundIndex;
                int end = foundIndex;

                // Рухаємось вліво, поки елементи дорівнюють шуканому
                while (start > 0 && sortedArray[start - 1] == target)
                    start--;
                // Рухаємось вправо, поки елементи дорівнюють шуканому
                while (end < sortedArray.Length - 1 && sortedArray[end + 1] == target)
                    end++;

                Console.Write($"Custom implementation: Element {target} found at indices: ");

                for (int i = start; i <= end; i++)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Custom implementation: Element not found.");
            }

            // Порівняння
            int builtInIndex = Array.BinarySearch(sortedArray, target);
            if (builtInIndex >= 0)
            {
                Console.WriteLine($"Array.BinarySearch: Match found at index {builtInIndex} (shows one of the occurrences).");
            }
            else
            {
                Console.WriteLine("Array.BinarySearch: Element not found.");
            }
        }

        /// <summary>
        /// Генерує матрицю зв'язків між дисциплінами (рядки) та компетентностями (стовпці).
        /// Знаходить найкращу/найгіршу дисципліну та непокриті компетентності.
        /// </summary>
        /// <param name="matrix">Повертає згенеровану матрицю.</param>
        static void Task6_GenerateAndAnalyzeMatrix(out int[,] matrix)
        {
            Console.WriteLine("\n- Matrix of disciplines and competencies -");

            int rows = GetValidInt("Enter the number of disciplines (rows): ");
            while (rows <= 0)
            {
                Console.WriteLine("Error: amount must be greater than 0.");
                rows = GetValidInt("Enter the number of disciplines (rows): ");
            }

            int cols = GetValidInt("Enter the number of competencies (columns): ");
            while (cols <= 0)
            {
                Console.WriteLine("Error: amount must be greater than 0.");
                cols = GetValidInt("Enter the number of competencies (columns): ");
            }

            matrix = new int[rows, cols];
            Random random = new Random();

            Console.WriteLine("\nRelationship matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(2); // Заповнюємо 0 (немає зв'язку) або 1 (є зв'язок)
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int disciplinesWithNoComp = 0;
            int maxCompCount = -1;
            string bestDisciplines = "";

            // Аналіз рядків (дисциплін)
            for (int i = 0; i < rows; i++)
            {
                int rowSum = 0; // Кількість компетенцій, які формує конкретна дисципліна
                for (int j = 0; j < cols; j++)
                    rowSum += matrix[i, j];

                if (rowSum == 0)
                    disciplinesWithNoComp++;

                if (rowSum > maxCompCount)
                {
                    maxCompCount = rowSum;
                    bestDisciplines = (i + 1).ToString();
                }
                else if (rowSum == maxCompCount)
                {
                    bestDisciplines += ", " + (i + 1).ToString(); // Якщо кілька дисциплін мають однаковий максимум
                }
            }

            Console.WriteLine($"\nNumber of disciplines forming NO competencies: {disciplinesWithNoComp}");
            Console.WriteLine($"Discipline(s) forming the MAXIMUM number of competencies ({maxCompCount}): {bestDisciplines}");

            // Аналіз стовпців (компетентностей)
            string uncoveredComps = "";
            for (int j = 0; j < cols; j++)
            {
                int colSum = 0; // Кількість дисциплін, що покривають цю компетентність
                for (int i = 0; i < rows; i++)
                    colSum += matrix[i, j];

                if (colSum == 0)
                {
                    if (uncoveredComps != "")
                        uncoveredComps += ", ";
                    uncoveredComps += (j + 1).ToString();
                }
            }

            if (uncoveredComps != "")
                Console.WriteLine($"Competencies NOT provided by any discipline: {uncoveredComps}");
            else
                Console.WriteLine("All competencies are covered by at least one discipline.");
        }

        /// <summary>
        /// Обчислює суму кожного стовпця матриці та сортує стовпці за зростанням цих сум.
        /// </summary>
        /// <param name="matrix">Матриця для сортування стовпців.</param>
        static void Task7_SortMatrixColumns(int[,] matrix)
        {
            Console.WriteLine("\n- Sort matrix columns by sum -");
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] colSums = new int[cols];
            // Обчислюємо суму елементів для кожного стовпця
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    colSums[j] += matrix[i, j];
                }
            }

            Console.Write("Column sums before sorting: \t");
            for (int i = 0; i < colSums.Length; i++)
            {
                Console.Write(colSums[i] + "\t");
            }
            Console.WriteLine();

            // Сортування масиву сум вибором, ПАРАЛЕЛЬНО переставляючи стовпці у матриці
            for (int i = 0; i < cols - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < cols; j++)
                {
                    if (colSums[j] < colSums[minIdx])
                        minIdx = j;
                }

                if (minIdx != i)
                {
                    // Міняємо місцями суми у допоміжному масиві
                    int tempSum = colSums[i];
                    colSums[i] = colSums[minIdx];
                    colSums[minIdx] = tempSum;

                    // Міняємо місцями цілі стовпці всередині матриці
                    for (int r = 0; r < rows; r++)
                    {
                        int tempVal = matrix[r, i];
                        matrix[r, i] = matrix[r, minIdx];
                        matrix[r, minIdx] = tempVal;
                    }
                }
            }

            Console.Write("Column sums after sorting: \t");
            for (int i = 0; i < colSums.Length; i++)
            {
                Console.Write(colSums[i] + "\t");
            }
            Console.WriteLine();

            Console.WriteLine("Matrix after column rearrangement:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Знаходить корінь рівняння x^3 + 4x^2 - 6x - 3 = 0 методом бісекції (ділення відрізка навпіл).
        /// </summary>
        static void Task8_BisectionMethod()
        {
            Console.WriteLine("\n- Bisection method -");

            // Локальна функція, що описує задане математичне рівняння
            double F(double x) => Math.Pow(x, 3) + 4 * Math.Pow(x, 2) - 6 * x - 3;

            Console.WriteLine("Equation: x^3 + 4x^2 - 6x - 3 = 0");

            double a = GetValidDouble("Enter the start of the interval (a): ");
            double b = GetValidDouble("Enter the end of the interval (b): ");
            double epsilon = GetValidDouble("Enter precision (e.g., 0.001): ");

            // Функція має змінювати знак на кінцях відрізка
            if (F(a) * F(b) >= 0)
            {
                Console.WriteLine("Error: The function must have different signs at the ends of the interval. Try another interval (e.g., a=1, b=2).");
                return;
            }

            double c = a;
            int iterations = 0;

            // Поки довжина половини відрізка більша за задану точність
            while ((b - a) / 2.0 > epsilon)
            {
                c = (a + b) / 2.0; 
                if (Math.Abs(F(c)) < epsilon)
                    break; // Якщо точно потрапили у корінь, зупиняємось

                // Звужуємо інтервал: вибираємо ту половину, на кінцях якої функція має різні знаки
                if (F(a) * F(c) < 0)
                    b = c; // Корінь між a та c
                else
                    a = c; // Корінь між c та b

                iterations++;
            }

            Console.WriteLine($"\nFound root x: {c}");
            Console.WriteLine($"Number of iterations: {iterations}");

            double result = F(c);

            Console.WriteLine($"Check: f({c}) = {result}");
            if (Math.Abs(result) <= epsilon)
                Console.WriteLine("Solution is correct (within the given error margin).");
        }

        /// <summary>
        /// Розбиває рядок на слова, знаходить слова з парною кількістю літер 
        /// та видаляє текст, що міститься у круглих дужках.
        /// </summary>
        static void Task9_StringManipulation()
        {
            Console.WriteLine("\n- String manipulation -");
            Console.WriteLine("Enter a string (with punctuation and text in parentheses):");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("The string is empty.");
                return;
            }

            // Масив розділових знаків для коректного розбиття на слова
            char[] separators = { ' ', ',', '.', '(', ')' };
            string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int evenLengthCount = 0;
            Console.WriteLine("\nWords with even length:");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length % 2 == 0) // Перевірка на парність довжини слова
                {
                    Console.WriteLine($"- {words[i]} (length: {words[i].Length})");
                    evenLengthCount++;
                }
            }
            Console.WriteLine($"Total number of such words: {evenLengthCount}");

            string resultStr = input;
            int startIdx;

            // Цикл шукає першу '(' у рядку
            while ((startIdx = resultStr.IndexOf('(')) != -1)
            {
                // Шукаємо закриваючу дужку ')' починаючи від знайденої відкриваючої
                int endIdx = resultStr.IndexOf(')', startIdx);

                if (endIdx != -1)
                {
                    // Видаляємо частину рядка від відкриваючої до закриваючої дужки (включно)
                    resultStr = resultStr.Remove(startIdx, endIdx - startIdx + 1);
                }
                else
                {
                    // Якщо відкриваюча дужка є, а закриваючої немає - перериваємо цикл щоб уникнути зациклення
                    break;
                }
            }
            Console.WriteLine($"\nString after removing text in parentheses:\n{resultStr}");
        }

        /// <summary>
        /// Метод для виводу масиву.
        /// </summary>
        /// <param name="array">Масив для виводу.</param>
        static void PrintArray(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Array is empty.");
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}