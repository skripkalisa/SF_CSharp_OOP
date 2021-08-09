using System;
using System.Runtime.CompilerServices;

namespace Mod7
{
    internal class Address
    {
        private protected string City;
        private protected string Street;
        private protected string Comment;

        internal Address(){}

        internal Address(string street)
        {
            City = "Москва";
            Street = street;
        }          
        internal Address(string city, string street)
        {
            City = city;
            Street = street;
        }        
        internal Address(string city, string street, string comment)
        {
            City = city;
            Street = street;
            Comment = comment;
        }
        internal string GetAddress()
        {
            string address = $"Адрес: ";
            if(City != null) address += $"г.{City}, ";
            else if(Street != null)address += $"ул. {Street}";
            else if (Comment != null) address += $". Комментарий: {Comment}";
            else address += $"не указан";
            address += ".";
            // Console.WriteLine(address);
            return address;
        }

    }
    internal class ExactAddress : Address
    {
        private protected int House;
        private protected int Building;
        private protected int Flat;
        private protected int Floor;
        private protected int Entrance;

        protected ExactAddress(){}
 
        internal ExactAddress(int house, int building, int flat, int floor, int entrance) 
        {
            House = house;
            Building = building;
            Flat = flat;
            Floor = floor;
            Entrance = entrance;
        }

        // internal ExactAddress(string city, string street, string comment) : base(city, street, comment)
        // {
        // }

        internal string GetFullAddress()
        {            
            string fullAddress = "Точный адрес: ";
            string emptyAddress = fullAddress;
            if(Street == null)
            {
                fullAddress += $"не указан.";
                Console.WriteLine(fullAddress);
                return fullAddress;
            }
            if(City != null) fullAddress += $"г.{City}";
            if (Street != null) fullAddress += $" ул. {Street}";
            if (House != 0) fullAddress += $", д.{House}, "; 
            if (Building != 0) fullAddress += $"корп./стр.{Building}";
            if (Flat != 0) fullAddress += $" - кв./оф.{Flat}. "; 
            if (Entrance != 0) fullAddress +=  $"{Entrance} подъезд, ";
            if (Floor != 0) fullAddress +=  $"{Floor} этаж.";
            if (fullAddress == emptyAddress)fullAddress += $"не указан.";
            if(Comment != null) fullAddress +=  $" Комментарии: {Comment}";
            // Console.WriteLine(fullAddress);
            return fullAddress;
        }
    }
}