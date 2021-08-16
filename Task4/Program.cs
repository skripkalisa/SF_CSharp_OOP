using System;
using System.IO;

namespace Task4
{
    public static class StreamEOF
    {
        public static bool EOF(this BinaryReader binaryReader)
        {
            var bs = binaryReader.BaseStream;
            return bs.Position == bs.Length;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var di = new DirectoryInfo("./");
            var workspace = di.Parent?.Parent?.Parent?.FullName + "/";
            var fileName = "Students.dat";
            var fileTxt = "st.txt";
            var path = workspace + "_" + fileName;
            var pathTxt = workspace + fileTxt;
            if (!File.Exists(path))
                MakeBinaryFile(pathTxt, path);
            ReadValues(path);
            Console.WriteLine($"Файлы успешно созданы в {workspace}Students");
        }


        private static void ReadValues(string path)
        {
            string stName;
            string stGroup;
            DateTime stDateOfBirth;


            if (!File.Exists(path)) return;
            var di = new DirectoryInfo(path);
            var parentPath = $"{di.Parent}";
            var studentsPath = $"{parentPath}/Students";
            if (Directory.Exists(studentsPath))
                DeleteRecursively(studentsPath);
            Directory.CreateDirectory(studentsPath);

                
            using var br =
                new BinaryReader(
                    File.Open($"{parentPath}/_Students.dat",
                        FileMode.Open));
            while (!br.EOF())
            {
                stName = br.ReadString();
                stGroup = br.ReadString();
                stDateOfBirth = DateTime.FromBinary(br.ReadInt64());

                CreateFiles(studentsPath, stGroup, stName, stDateOfBirth);

                // Console.WriteLine("Из файла считано:");
                // Console.WriteLine("Имя: " + stName);
                // Console.WriteLine("Группа: " + stGroup);
                // Console.WriteLine("Дата рождения: " + stDateOfBirth.Date.ToString("d"));
            }
        }

        private static void CreateFiles(string studentsPath, string stGroup, string name, DateTime dateOfBirth)
        {
            using var stream = new FileStream($"{studentsPath}/{stGroup}.txt", FileMode.OpenOrCreate, FileAccess.Write,
                FileShare.Write);
            using var sw = File.AppendText($"{studentsPath}/{stGroup}.txt");
            sw.WriteLine($"Имя: {name}, дата рождения: {dateOfBirth.Date:d} ");
        }

        private static void MakeBinaryFile(string pathTxt, string path)
        {
            var lines = File.ReadLines(pathTxt);
            foreach (var line in lines)
            {
                var r = new Random();
                var student = line.Split(" ");
                var dt = new DateTime(r.Next(2000, 2010), r.Next(1, 12), r.Next(1, 28));
                var st = new Student(student[0], student[1], dt.Date);
                st.AddStudent(path);
            }
        }

        private static void DeleteRecursively(string userPath)
        {
            var di = new DirectoryInfo(userPath);

            foreach (var file in di.EnumerateFiles())
                try
                {
                    file.Delete();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не могу удалить файл: " + e.Message);
                    // throw;
                }

            foreach (var dir in di.EnumerateDirectories())
                try
                {
                    dir.Delete(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не могу удалить каталог: " + e.Message);
                    // throw;
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
    }
}