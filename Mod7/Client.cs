using System;
using System.Threading.Channels;

namespace Mod7
{
    internal class Client : ExactAddress
    {
        private string FirstName;
        private string LastName;
        private string Phone;
        private string Delivery;
        
        internal Client()
        {
            FirstName = "Частное лицо";
            Delivery = "Самовывоз";
            
        }        
        internal Client(string firstName)
        {
            FirstName = firstName;
        }
        
        internal Client(string firstName, string phone= null, string delivery = "Самовывоз")
        {
            FirstName = firstName;
            Phone = phone;
            Delivery = delivery;
        }

        internal Client(string firstName, string lastName, string phone, string delivery = "Самовывоз")
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Delivery = delivery;
        }


        internal void SetAddress(string street,string city = "Москва",  string comment = null) 
        {
            City = city;
            Street = street;
            Comment = comment;
        }

        internal void SetExactAddress(int house, int building, int flat, int floor, int entrance)
        {
            if(Street == null) Console.WriteLine("Надо сначала указать улицу");
            House = house;
            Building = building;
            Flat = flat;
            Floor = floor;
            Entrance = entrance;
        }

        internal string GetInfo()
        {
            string clientInfo = $"Имя: {FirstName}";
            if (LastName != null) clientInfo += $" {LastName}";
            if (Phone != null) clientInfo += $". Тел.: {Phone}";
            
            clientInfo += $". Доставка: {Delivery}.";
            // Console.WriteLine(clientInfo);
            return clientInfo;
        }

        internal string GetClientAddress()
        {
            Delivery = GetFullAddress();
            // Console.WriteLine(Delivery);
            return Delivery;
        }
    }
}