// using System.Runtime.InteropServices;
using System;

namespace Mod6
{
  class Pen
  {

    public string color;
    public int cost;
    public Pen()
    {
      color = "Черный";
      cost = 100;
    }
    public Pen(string color, int cost)
    {
      this.color = color;
      this.cost = cost;
    }

  }
  class Rectangle
  {
    public int a;
    public int b;

    public Rectangle()
    {
      a = 6;
      b = 4;
    }

    public Rectangle(int side)
    {
      a = side;
      b = side;
    }

    public Rectangle(int first, int second)
    {
      a = first;
      b = second;
    }

    public int Square()
    {
      return a * b;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var num = 1;

      AddTen(ref num);

      Console.WriteLine(num);

      Pen pen1 = new Pen();
      System.Console.WriteLine(pen1.color + pen1.cost);
      Pen pen2 = new Pen("White", 200);
      System.Console.WriteLine(pen2.color + pen2.cost);

      Rectangle sq = new Rectangle(5);
      Console.WriteLine(sq.Square());


    }

    static void AddTen(ref int num)
    {
      num = num + 10;
    }
  }
}
