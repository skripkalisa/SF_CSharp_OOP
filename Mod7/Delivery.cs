using System.Buffers.Text;
using System.Collections.Generic;

namespace Mod7
{
    abstract class Delivery : Client
    {
        protected abstract void GetDeliveryAddress();
        internal abstract List<string> GetDetails();
    }

    class  HomeDelivery : Delivery
    {
        private string ClientInfo;
        private string ClientAddress;
        private List<string> DeliveryDetails;

        protected override void GetDeliveryAddress()
        {
            ClientInfo = GetInfo();
            ClientAddress = GetClientAddress();
            DeliveryDetails.Add(ClientInfo);
            DeliveryDetails.Add(ClientAddress);
        }

        internal override List<string> GetDetails()
        {
            GetDeliveryAddress();
            return DeliveryDetails;
        }
        
        /* ... */
    }

    // class PickPointDelivery : Delivery
    // {
    //     /* ... */
    // }
    //
    // class ShopDelivery : Delivery
    // {
    //     /* ... */
    // }

}