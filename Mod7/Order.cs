using System;

namespace Mod7
{
    class Order<TDelivery,
        TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Delivery);
        }

        // ... Другие поля
    }
}