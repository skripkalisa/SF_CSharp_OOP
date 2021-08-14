using System;
using System.IO;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userPath = "../../../";

            Console.WriteLine("Программа считает размер папки на диске " +
                              "(вместе со всеми вложенными папками и файлами). " +
                              "\nНа вход метод принимает URL директории, в ответ — размер в байтах.");

            Console.Write("Для рассчёта размера введите путь к файлу или каталогу: ");
            var input = Console.ReadLine();
            userPath = UserPath(input, userPath);

            var di = new DirectoryInfo(userPath);
            var parent = di.Parent;

            // Console.WriteLine("Папки:"); 
            // Console.WriteLine(parent.GetFiles());
            // FileInfo[] dirs = parent?.GetFiles();  // Получим все директории корневого каталога

            var count = DirSize(di);
            Console.WriteLine($"Размер каталога {di.Name}: {count} байт");
            count = DirSize(parent);
            Console.WriteLine($"Размер родительского каталога {parent?.Name}: {count} байт");
        }

        private static long DirSize(DirectoryInfo dir)
        {
            long size = 0;
            try
            {
                size = dir.EnumerateFiles().Sum(fi => fi.Length) +
                       dir.EnumerateDirectories().Sum(DirSize);
            }
            catch (Exception e)
            {
                Console.WriteLine("Не могу посчитать размер: " + e.Message);
                // throw;
            }

            return size;
        }

        private static string UserPath(string? input, string userPath)
        {
            if (Directory.Exists(input))
                userPath = input;
            else
                Console.WriteLine("Нет такого файла или каталога. " +
                                  $"Использую значение по умолчанию: {userPath}");
            return userPath;
        }
    }
}