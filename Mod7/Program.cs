using System;
using System.Threading.Channels;

namespace Mod7
{
    class Program
    {
        static void Main(string[] args)
        {
            Client cl1 = new Client("Остап", "Задунайский", "+12345678963", "На дом");
            // cl1.GetInfo();
            cl1.SetExactAddress(32,2,184, 2, 1);
            // cl1.GetClientAddress();
            cl1.SetAddress("просп. Мира");
            // cl1.GetClientAddress();
            
            Product sushi = new Sushi("Чука", "водоросли чука", "Суши с морскими водорослями", 50, 100);
            // sushi.GetProduct();
            //
            Delivery<Client> homeDelivery = new HomeDelivery(cl1);
            // // homeDelivery.GetDetails();
            Payment payment = new Payment(false, "Card", true);
            // // payment.getStatus();
            Order<Delivery<Client>, Client, Product, Payment> order1=
            new Order<Delivery<Client>, Client, Product, Payment>(homeDelivery, cl1, sushi, payment);
            order1.FulfilOrder();
            
            Console.WriteLine("\n");
            Client cl2 = new Client();
            Payment p2 = new Payment(true);
            Delivery < Client > d2= new ShopDelivery(cl2);
            Order<Delivery<Client>, Client, Product, Payment> o2 =
                new Order<Delivery<Client>, Client, Product, Payment>(d2, cl2, new Sushi("Лосось", "лосось", "Суши с красной рыбой", 150, 150),p2);
            o2.FulfilOrder();
        }
    }
}