using System;
using System.Buffers.Text;
using System.Collections.Generic;

namespace Mod7
{
    abstract class Delivery<TClient> where TClient: Client
    {
        private protected TClient Client;
        private string ClientInfo;
        private string ClientAddress;
        private List<string> DeliveryDetails;

        private protected abstract void GetDeliveryAddress();

        internal abstract List<string> GetDetails();

    }

    class  HomeDelivery : Delivery<Client>
    {
        private string ClientInfo;
        private string ClientAddress;
        private List<string> DeliveryDetails;        

        public HomeDelivery(Client client)
        {
            ClientInfo = client.GetInfo();
            ClientAddress = client.GetFullAddress();

        }

        private protected override void GetDeliveryAddress()
        {
            List<string> deliveryDetails = new List<string>();
            deliveryDetails.Add(ClientInfo);
            deliveryDetails.Add(ClientAddress);
            DeliveryDetails = deliveryDetails;
        }

        internal override List<string> GetDetails()
        {
            GetDeliveryAddress();
            foreach (string detail in DeliveryDetails)
            {
                Console.WriteLine(detail);
            }
            return DeliveryDetails;
        }

    }


    class ShopDelivery : Delivery<Client>
    { 
        private string ClientInfo;
        private List<string> DeliveryDetails;
        /* ... */
        public ShopDelivery(Client client)
        {
            ClientInfo = client.GetInfo();
        }

        private protected override void GetDeliveryAddress()
        {
            List<string> deliveryDetails = new List<string> { ClientInfo };
            DeliveryDetails = deliveryDetails;
        }

        internal override List<string> GetDetails()
        {
            GetDeliveryAddress();
            foreach (string detail in DeliveryDetails)
            {
                Console.WriteLine(detail);
            }
            return DeliveryDetails;
        }
    }

}