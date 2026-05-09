using System;
using System.IO;
using System.Text;
using Console_Lab_5.models;

namespace Console_Lab_5
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== ТЕСТУВАННЯ КОНСТРУКТОРІВ ===");
            City defaultCity = new City();
            Village paramVillage = new Village("Ксаверівка", 2, 12.5, 3000, "Київська область", 12000, 5);
            UrbanVillage copyUrbanVillage = new UrbanVillage(new UrbanVillage("Гостомель", false, 15.0, 17000, "Передмістя Києва", 18000, 7));

            City kyiv = new City("Київ", 50000000000, 10, 839, 2900000, "Центр", 30000, 10);
            Village sofia = new Village("Софіївська Борщагівка", 1, 7.08, 27500, "Захід", 22000, 8);

            Console.WriteLine("\n=== ТЕСТУВАННЯ ПОЛІМОРФІЗМУ (ВІРТУАЛЬНІ МЕТОДИ) ===");
            kyiv.Invest();
            paramVillage.Invest();
            copyUrbanVillage.Invest();

            Console.WriteLine();
            kyiv.Migrate();
            paramVillage.Migrate();
            copyUrbanVillage.Migrate();

            Console.WriteLine("\n=== ТЕСТУВАННЯ БІНАРНИХ ОПЕРАТОРІВ ===");
            Console.WriteLine($"Сумарне населення Києва та Софіївської Борщагівки: {kyiv + sofia}");
            Console.WriteLine($"Різниця в населенні: {kyiv - sofia}");
            Console.WriteLine($"Вартість життя в Києві більша ніж у Софіївській Борщагівці? {kyiv > sofia}");
            Console.WriteLine($"Чи однакове населення у Києва та Ксаверівки? {kyiv == paramVillage}");

            Console.WriteLine("\n=== ТЕСТУВАННЯ УНАРНИХ ОПЕРАТОРІВ ===");
            Console.WriteLine($"Рейтинг Києва до збільшення: {kyiv.Rating}");

            Console.WriteLine($"Кількість районів у Києві: {kyiv.DistrictsCount}");
            kyiv--; // Зменшення районів

            Console.WriteLine($"Населення Ксаверівки до кризи: {paramVillage.Population}");
            paramVillage = (Village)(-paramVillage); // Зменшення населення
            Console.WriteLine($"Населення Ксаверівки після кризи (-): {paramVillage.Population}");

            Console.WriteLine("\n=== ТЕСТУВАННЯ ІНДЕКСАТОРА ===");
            LocalityCollection region = new LocalityCollection(3);
            region[0] = kyiv;
            region[1] = paramVillage;
            region[2] = copyUrbanVillage;

            for (int i = 0; i < region.Length; i++)
            {
                Console.WriteLine($"Елемент[{i}]: Населення = {region[i].Population}, Вартість життя = {region[i].CostOfLiving}");
            }
        }
    }
}