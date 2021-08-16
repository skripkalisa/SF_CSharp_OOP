using System;
using System.IO;

namespace Task4
{
    public class Student
    {
        private string Name;
        private string Group;
        private DateTime DateOfBirth;

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }

        public void AddStudent(string path)
        {
            using var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            using BinaryWriter wr = new BinaryWriter(fileStream);
            wr.Write(Name);
            wr.Write(Group);
            wr.Write(DateOfBirth.ToBinary());
        }
    }
}