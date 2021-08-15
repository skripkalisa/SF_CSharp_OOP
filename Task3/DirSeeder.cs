using System;
using System.Collections;
using System.IO;

namespace Task3
{
    public class DirSeeder
    {
        private readonly ArrayList _files = new();
        private readonly ArrayList _folders = new();
        private readonly int _limit;
        private readonly string _path;
        private readonly ArrayList _subfolders = new();

        internal DirSeeder(int limit, string path)
        {
            if (limit is > 0 and < 26)
            {
                _limit = limit;
            }
            else
            {
                _limit = 10;
                Console.WriteLine("Неверный задан параметр limit." +
                                  "В целях безопасности количество ветвей ограничено в пределах от 1 до 25 включительно." +
                                  $"\nИспользую значение по умолчанию: {_limit}.");
            }

            _path = path;
        }

        public void Populate()
        {
            Seed(_limit, _path);
        }

        private void Seed(int limit, string path)
        {
            // Directory di = new Directory(path);
            for (var i = 0; i < limit; i++)
            {
                _folders.Add("folder_" + i);
                _subfolders.Add("subfolder_" + i);
                _files.Add("file_" + i);
            }

            var di = new DirectoryInfo(path);

            if (!di.Exists) di.Create();

            try
            {
                foreach (string folder in _folders)
                {
                    var fld = $"{path}/{folder}";
                    if (!Directory.Exists(fld))
                        Directory.CreateDirectory(fld);
                    foreach (string subfolder in _subfolders)
                    {
                        var subfld = $"{fld}/{subfolder}";
                        if (!Directory.Exists(subfld))
                            Directory.CreateDirectory(subfld);
                        foreach (string file in _files)
                        {
                            var f = $"{subfld}/{file}.tmp";
                            if (!File.Exists(f))
                            {
                                // File.Create(f);
                                using var sw = File.CreateText(f);
                                sw.Write(DateTime.Now);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Нет доступа: " + e.Message);
                // throw;
            }
        }
    }
}