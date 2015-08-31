using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookinSystem.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
            this.RegistrationDate = DateTime.Now;
        }
    }
}