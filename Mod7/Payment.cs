using System;
using System.Collections.Generic;

namespace Mod7
{
    public class Payment
    {
        private bool UpFront;
        private string PaymentType;
        private bool IsComplete;

        private readonly List<string> _paymentType = new() {"Наличные", "Карта", "Онлайн", "Бартер"};
        internal Payment(bool upFront, string paymentType)
        {
            UpFront = upFront;
            PaymentType = _paymentType.Contains(paymentType) ? paymentType : "Наличные";
            IsComplete = upFront;
        }        
        internal Payment(bool upFront, string paymentType, bool isComplete)
        {
            UpFront = upFront;
            PaymentType = _paymentType.Contains(paymentType) ? paymentType : "Наличные";
            IsComplete = upFront || isComplete;
        }


        public bool UpFront1
        {
            get => UpFront;
            set => UpFront = value;
        }

        public void getStatus()
        {
            if(UpFront)
                Console.WriteLine($"Предоплата. Способ оплаты: {PaymentType}" );
            else
            {
                Console.Write("Статус платежа: ");
                Console.WriteLine(IsComplete ? "погашен." : "ожидается.");
                Console.WriteLine($"Способ оплаты: {PaymentType}" );
            }
        }

    }
}