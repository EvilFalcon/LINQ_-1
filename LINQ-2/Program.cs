using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>()
            {
                new Criminal("Педро Алонсо Лопес", 165, 75, "Колумбиец", false),
                new Criminal("Усама бен Ладан", 180, 85, "Аравииц", true),
                new Criminal("Матео Мессина Денаро", 165, 75, "Итальянец", false),
                new Criminal("Джозеф Кони", 165, 75, "Угандиец", true),
            };

            Console.WriteLine("Введите рост преступника :");
            int height = ReadInt();
            
            Console.WriteLine("Введите вес  преступника :");
            int weight = ReadInt();
            
            Console.WriteLine("Введите   национальность :");
            string nationality = Console.ReadLine();
            

            var searchResults = from Criminal criminal in criminals
                where nationality != null &&
                      criminal.Height == height &&
                      criminal.Weight == weight &&
                      criminal.Nationality.ToLower() == nationality.ToLower() &&
                      criminal.IsDetained == false
                select criminal;

            foreach (var criminal in searchResults)
            {
                Console.WriteLine($"{criminal.FullName}");
            }
        }

        public static int ReadInt()
        {
            int result;
            while (int.TryParse(Console.ReadLine(),out result)==false)
            {
                Console.WriteLine("неверный ввод");
            }

            return result;
        }
    }

    public class Criminal
    {
        public Criminal(string fullName, int height, int weight, string nationality, bool isDetained)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsDetained = isDetained;
        }

        public string FullName { get; }
        public int Height { get; }
        public int Weight { get; }
        public string Nationality { get; }
        public bool IsDetained { get; }
    }
}