using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookinSystem.Controllers
{
    class SecurePaymentToken
    {
        public string CardAddressCountry { get; set; }
        public string CardAddressLine1 { get; set; }
        public string CardAddressLine2 { get; set; }
        public string CardAddressCity { get; set; }
        public string CardAddressZip { get; set; }
        public int CardCvc { get; set; }
        public int CardExpirationMonth { get; set; }
        public int CardExpirationYear { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }

        public SecurePaymentToken()
        {
        }

        public SecurePaymentToken(string CardAddressCountry, string CardAddressLine1, string CardAddressLine2, string CardAddressCity, string CardAddressZip, int CardCvc, int CardExpirationMonth, int CardExpirationYear, string CardName, string CardNumber)
        {
            this.CardAddressCountry = CardAddressCountry;
            this.CardAddressLine1 = CardAddressLine1;
            this.CardAddressLine2 = CardAddressLine2;
            this.CardAddressCity = CardAddressCity;
            this.CardAddressZip = CardAddressZip;
            this.CardCvc = CardCvc;
            this.CardExpirationMonth = CardExpirationMonth;
            this.CardExpirationYear = CardExpirationYear;
            this.CardName = CardName;
            this.CardNumber = CardNumber;
        }
    }
}
