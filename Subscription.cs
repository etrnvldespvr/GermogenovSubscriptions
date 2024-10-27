using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermogenovSubscriptions
{
    public class Subscription
    {
        public string ServiceName { get; set; }
        public string NextPaymentDate { get; set; }
        public string MonthlyCost { get; set; }
        public string PaymentMethod { get; set; }
        public string Plan { get; set; }
        public bool IsPlanAvailable { get; set; } // Новое свойство для условного отображения плана

        public bool IsCanceled => MonthlyCost == "0 руб.";

        public void CancelSubscription()
        {
            NextPaymentDate = "Отменена";
            MonthlyCost = "0 руб.";
            Plan = null; // Сбрасываем план
            PaymentMethod = null; // Сбрасываем метод оплаты
        }


    }
}
