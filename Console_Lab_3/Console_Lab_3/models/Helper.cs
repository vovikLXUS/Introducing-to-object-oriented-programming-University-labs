using System;
using System.Text;

namespace Console_Lab_3.models
{
    public static class Helper
    {
        public static int GetInt(string request)
        {
            int result;

            Console.Write(request);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid integer.");
                Console.Write(request);
            }
            return result;
        }
        public static long GetLong(string request)
        {
            long result;

            Console.Write(request);
            while (!long.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Error: please enter a valid integer.");
                Console.Write(request);
            }
            return result;
        }
    }
}
