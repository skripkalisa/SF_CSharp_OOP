#nullable enable
using System;
using System.IO;
using System.Linq;

namespace Task3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var userPath = "../../../temp";
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

            var di = new DirectoryInfo(userPath);

            var count = DirSize(di.Parent);
            var parentBefore = count;
            Console.WriteLine($"До очистки размер каталога {di.Parent}: {count} байт");
            count = DirSize(di);
            Console.WriteLine($"Исходный размер каталога: {count} байт");

            UserPathInfo(di.FullName);

            Console.WriteLine("Вы уверены, что хотите удалить эти данные?");
            Console.WriteLine("Y/n");
            var confirm = Console.ReadLine();
            if (confirm is "Y" or "y")
            {
                DeleteRecursively(userPath, span);
                count = DirSize(di.Parent);
                Console.WriteLine($"После очистки размер каталога {di.Parent}: {count} байт");
                Console.WriteLine($"Освобождено: {parentBefore - count} байт");
                if (di.Exists)
                {
                    Console.WriteLine("Эти файлы не были удалены:");
                    UserPathInfo(di.FullName);
                }
            }
            else
            {
                Console.WriteLine("Удаление данных отменено пользователем." +
                                  "\nВыход из программы.");
            }
        }

        private static void UserPathInfo(string di)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(di))
                {
                    foreach (var file in Directory.GetFiles(dir))
                        Console.WriteLine($"{file} : занимает {file.Length} байт на диске");
                    UserPathInfo(dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не могу посчитать размер: " + e.Message);
                // throw;
            }
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

        private static long DirSize(DirectoryInfo? dir)
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

        private static string UserPath(string input, string userPath)
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