using System;
namespace Mod7
{
  public class Address
  {
    public Address(string city, string street, string comment)
    {
      City = city;
      Street = street;
      Comment = comment;
    }
    private string City;
    // private string city = "Москва";
    private string Street;

    private string Comment;
    internal void getAddress()
    {
      Console.WriteLine($"Адрес клиента: {this.City}, {this.Street}, {this.Comment}");
    }

  }
  public class ExactAddress : Address
  {
    private int House;
    private int Building;
    // private int Building = 0;
    private int Flat;
    private int Floor;
    private int Entrance;
    public ExactAddress(int house, int building, int flat, int floor, int entrance) : this()
    {
      House = house;
      Building = building;
      Flat = flat;
      Floor = floor;
      Entrance = entrance;
    }
    internal void getAddress()
    {
      Console.WriteLine($"Точный адрес клиента: г.{this.City}, ул. {this.Street}, д.{this.House}, корп./стр.{this.Building} - кв./оф.{this.Floor}. {this.Entrance} подъезд, {this.Floor} этаж. Комментарии: {this.Comment}");
    }
  }
}
