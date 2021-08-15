﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// using System.Text;

// byte[] bt;
// bt = File.ReadAllBytes(path);
// string file = Encoding.UTF8.GetString(bt);
// Console.WriteLine(file);
namespace Task4
{
    [Serializable]
    class BinFile
    {
        // public string Name;
        // public string Group;
        // public DateTime Dt;
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime Dt { get; set; }

        public BinFile(string name, string group, DateTime dt)
        {
            Name = name;
            Group = group;
            Dt = dt;
        }

        public BinFile()
        {
        }

        // public GetInfo()
        // {
        //     
        // }

        
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo("./");
            var workspace = di.Parent?.Parent?.Parent?.FullName + "/";
            
            string fileName = "Students.dat";
            string oldName = workspace + fileName;
            var path = workspace + "_" + fileName;
            FileInfo fi = new FileInfo(oldName);
            if(File.Exists(path))
                File.Delete(path);
            fi.CopyTo(path);

            // Console.WriteLine(workspace);
            // BinFile bf = new BinFile();
            // new BinFile().GetStudents(workspace);
            // bf.GetStudents(workspace);
            // student.GetStudents(workspace);
            // BinaryFormatter formatter = new BinaryFormatter();
            // using (var fs = new FileStream(workspace, FileMode.Open))
            // {
            //     formatter.Serialize(fs, student);
            //     Console.WriteLine("Объект сериализован");
            //     Console.WriteLine($"Имя: {student.Name} --- Возраст: {student.Group}");
            // }
            // using (var fs = new FileStream(workspace, FileMode.Open))
            // {
            //     var student2 = (BinFile)formatter.Deserialize(fs);
            //     Console.WriteLine("Объект десериализован");
            //
            //     Console.WriteLine($"Имя2: {student2.Name} --- Возраст2: {student2.Group}");
            // }
            GetStudents(path);
        }
        public static void GetStudents(string path)
        {

            BinFile student = new BinFile("N", "G", DateTime.Now);
            // Console.WriteLine($"Name: {student.Name}; Group: {student.Group}; Birthday: {student.Dt}");
            BinaryFormatter formatter = new BinaryFormatter();  
            using (var fs = new FileStream(path, FileMode.Open))
            {
                // formatter.Serialize(fs, student);
                try
                {
                    student = (BinFile)formatter.Deserialize(fs);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не могу прочитать грёбаный файл: \n"+e.Message);
                    // throw;
                }
            
                Console.WriteLine($"Name: {student.Name}; Group: {student.Group}; Birthday: {student.Dt}");
            }
            // using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            // {
            //     string name = br.ReadString();
            //     string group = br.ReadString();
            //     DateTime dt = DateTime.FromBinary(br.Read());
            //
            //     Console.WriteLine($"Name2: {name}; Group2: {group}; Birthday2: {dt}");
            //     
            //     
            //     name = br.ReadString();
            //     group = br.ReadString();
            //     dt = DateTime.FromBinary(br.Read());
            //
            //     Console.WriteLine($"Name2: {name}; Group2: {group}; Birthday2: {dt}");                
            //     
            //     name = br.ReadString();
            //     group = br.ReadString();
            //     dt = DateTime.FromBinary(br.Read());
            //
            //     Console.WriteLine($"Name2: {name}; Group2: {group}; Birthday2: {dt}");                
            //     
            //     name = br.ReadString();
            //     group = br.ReadString();
            //     dt = DateTime.FromBinary(br.Read());
            //
            //     Console.WriteLine($"Name2: {name}; Group2: {group}; Birthday2: {dt}");
            // }

                
        }
    }
}