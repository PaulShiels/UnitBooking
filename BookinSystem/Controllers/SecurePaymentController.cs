using Newtonsoft.Json;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookinSystem.Controllers
{
    public class SecurePaymentController : Controller
    {

        // GET: SecurePayment
        [HttpGet]
        public ActionResult Index()//StripeTokenCreateOptions token)
        {
            return View("SecurePayment");            
        }

        [HttpPost]
        public ActionResult Index(FormCollection tokenString)
        {
            if (tokenString == null)
            {
                return View("SecurePayment");
            }

            else
            {
                try
                {
                    var myCharge = new StripeChargeCreateOptions();

                    // always set these properties
                    myCharge.Amount = 120;
                    myCharge.Currency = "eur";

                    // set this if you want to
                    myCharge.Description = "Charge it like it's hot";

                    // setting up the card
                    myCharge.Source = new StripeSourceOptions()
                    {
                        // set this property if using a token
                        TokenId = tokenString[0],

                        // set these properties if passing full card details (do not
                        // set these properties if you set TokenId)
                        //Number = "4242424242424242",
                        //ExpirationYear = "2022",
                        //ExpirationMonth = "10",
                        //AddressCountry = "US",                // optional
                        //AddressLine1 = "24 Beef Flank St",    // optional
                        //AddressLine2 = "Apt 24",              // optional
                        //AddressCity = "Biggie Smalls",        // optional
                        //AddressState = "NC",                  // optional
                        //AddressZip = "27617",                 // optional
                        //Name = "Joe Meatballs",               // optional
                        //Cvc = "1223"                          // optional
                    };

                    // set this property if using a customer
                    //myCharge.CustomerId = *customerId*;

                    // set this if you have your own application fees (you must have your application configured first within Stripe)
                    //myCharge.ApplicationFee = 25;

                    // (not required) set this to false if you don't want to capture the charge yet - requires you call capture later
                    myCharge.Capture = true;

                    var chargeService = new StripeChargeService();
                    StripeCharge stripeCharge = chargeService.Create(myCharge);
                    return View("PaymentSuccess");
                }
                catch
                {
                    return View("SecurePayment");
                }
            }
        }
    }
}