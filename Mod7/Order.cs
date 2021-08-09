using System;

namespace Mod7
{
    class Order<TDelivery, TClient, TProduct, TPayment> 
        where TDelivery : Delivery<Client> 
        where TClient : Client
        where TProduct : Product
        where  TPayment : Payment
    
        // : Client
    {
        private TDelivery Delivery;
        private TClient Client;
        private TProduct Product;
        private TPayment  Payment;
        private static int id;


        public Order(TDelivery delivery, TClient client, TProduct product, TPayment payment)
        {
            Delivery = delivery;
            Client = client;
            Product = product;
            Payment = payment;
            id++;
        }

        public void FulfilOrder()
        {
            Console.WriteLine("Заказ: " + id);
            Console.WriteLine("Клиент: " + Client.GetInfo());

            Console.WriteLine("Состав заказа: " );
            Product.GetProduct();

            Console.WriteLine("Информация об оплате. ");
            Payment.getStatus();
            Console.WriteLine("Информация о доставке:");
            Delivery.GetDetails();

        }

        // ... Другие поля
    }
}