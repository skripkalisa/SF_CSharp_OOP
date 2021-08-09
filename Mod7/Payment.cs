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
        internal Payment(bool upFront, string paymentType = "Наличные")
        {
            UpFront = upFront;
            PaymentType = paymentType;
            IsComplete = upFront;
        }        
        internal Payment(bool upFront, string paymentType, bool isComplete)
        {
            UpFront = upFront;
            PaymentType = _paymentType.Contains(paymentType) ? paymentType : "Наличные";
            IsComplete = upFront || isComplete;
        }
        
        public string getStatus()
        {
            string s = "Статус платежа: ";
            if(UpFront) s += $"Предоплата.";
            else s += IsComplete ? "погашен." : "ожидается.";
            s += $"\nСпособ оплаты: {PaymentType}";
            Console.WriteLine(s);
            return s;
        }

    }
}