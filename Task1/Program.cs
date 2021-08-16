using System;
using System.IO;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var di = new DirectoryInfo("./");
            var userPath = di.Parent?.Parent?.Parent?.FullName + "/temp";
            var span = 5;
            Console.WriteLine("Программа удалит файлы и каталоги, " +
                              "с момента последнего использования которых " +
                              "прошло заданное время. " +
                              $"\nЗначение по умолчанию - {span} минут. ");

            Console.Write("Введите путь к файлу или каталогу, которые нужно почистить: ");
            var input = Console.ReadLine();
            userPath = UserPath(input, userPath);

            Console.Write("Введите количество минут с момента последнего использования: ");
            span = GetInterval(span);

            DeleteRecursively(userPath, span);
            if (!Directory.Exists(userPath))
                Console.WriteLine("Данные успешно удалены.");
        }

        private static int GetInterval(int span)
        {
            try
            {
                span = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода: " + e.Message);
                Console.WriteLine("Использую значение по умолчанию: " + span);
                // throw;
            }

            return span;
        }

        private static void DeleteRecursively(string userPath, int span)
        {
            var di = new DirectoryInfo(userPath);
            var now = DateTime.Now;

            foreach (var file in di.EnumerateFiles())
            {
                var dtf = File.GetLastAccessTime(file.ToString());
                var ts = now.Subtract(dtf);

                if (ts > TimeSpan.FromMinutes(span))
                    try
                    {
                        file.Delete();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не могу удалить файл: " + e.Message);
                        // throw;
                    }
            }

            foreach (var dir in di.EnumerateDirectories())
            {
                var dtdir = File.GetLastAccessTime(dir.ToString());
                var ts = now.Subtract(dtdir);

                if (ts > TimeSpan.FromMinutes(span))
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Не могу удалить каталог: " + e.Message);
                        // throw;
                    }
            }

            try
            {
                di.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine("Не могу удалить заданный каталог: " + e.Message);
                // throw;
            }
        }

        private static string UserPath(string? input, string userPath)
        {
            if (Directory.Exists(input))
            {
                userPath = input;
            }
            else
            {
                Console.WriteLine("Нет такого файла или каталога. " +
                                  $"Использую значение по умолчанию: {userPath}");
                var ds = new DirSeeder(2, userPath);
                ds.Populate();
                Console.WriteLine("Для удаления файлов из этого каталога " +
                                  "перезапустите программу и укажите количество минут: 0");
            }

            return userPath;
        }
    }
}