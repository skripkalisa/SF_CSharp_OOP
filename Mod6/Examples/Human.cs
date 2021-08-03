using System;

namespace Mod6.Examples
{
  class Human
  {
    // Поля класса
    public string name;
    public int age;

    // Метод класса
    public void Greetings()
    {
      Console.WriteLine("Меня зовут {0}, мне {1}", name, age);
    }
  }

  struct Animal
  {
    // Поля структуры
    public string type;
    public string name;
    public int age;

    // Метод структуры
    public void Info()
    {
      Console.WriteLine("Это {0} по кличке {1}, ему {2}", type, name, age);
    }
  }
}