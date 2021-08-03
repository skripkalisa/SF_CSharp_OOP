using System;

namespace Mod6
{
  class Program
  {
    static void Main(string[] args)
    {
      var num = 1;

      AddTen(ref num);

      Console.WriteLine(num);

    }

    static void AddTen(ref int num)
    {
      num = num + 10;
    }
  }
}
