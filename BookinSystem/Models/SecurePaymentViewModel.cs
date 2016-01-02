using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookinSystem.Controllers
{
    class SecurePaymentViewModel
    {
        public double TotalCost { get; set; }
        public static SecurePaymentViewModel CurentPayment;

        public SecurePaymentViewModel(double TotalCost)
        {
            this.TotalCost = TotalCost;
        }
    }
}
