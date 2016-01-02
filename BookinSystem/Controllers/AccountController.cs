using BookinSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace BookinSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Login");
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult loginUser()
        //{
        //    UserModel viewModel = new UserModel();
        //    return View(viewModel);
        //}

        [HttpPost]
        public JsonResult Login(string email, string password) //HttpResponseBase response)//Models.UserModel user)
        {
            UserModel u = new UserModel(email, password);
            if (ModelState.IsValid)
            {
                if (IsValid(email, password))
                {
                    // Create the authentication ticket with custom user data.
                    var serializer = new JavaScriptSerializer();
                    string userData = serializer.Serialize(u);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                            email,
                            DateTime.Now,
                            DateTime.Now.AddDays(30),
                            true,
                            userData,
                            FormsAuthentication.FormsCookiePath);

                    // Encrypt the ticket.
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    // Create the cookie.
                    System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    //result = true;

                    //FormsAuthentication.SetAuthCookie(email, false);
                    //return Json(new { result = "Redirect", url = Url.Action("WelcomeNewUser", "User") });

                }
                else
                {
                    //ModelState.AddModelError("Error", "Login data is incorrect");
                    return Json(new { result = "error", message = "Email or Password is incorrect" });
                }
            }
            //return new EmptyResult();
            return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpPost]
        public JsonResult Registration(string email, string password)//Models.UserModel user)
        {
            UserModel user = new UserModel(email, password);
            if (ModelState.IsValid)
            {
                using (var db = new UnitBookingDataContext())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrpPass = crypto.Compute(user.Password);

                    User u = new User()
                    {
                        Email = user.Email,
                        Password = encrpPass,
                        PasswordSalt = crypto.Salt
                    };

                    try
                    {
                        //Retrieve the first user account with an email mathcing the email provided
                        var dbUserAccount = db.Users.FirstOrDefault(uAcc => uAcc.Email == email);
                        if (dbUserAccount == null)
                        {
                            db.Users.InsertOnSubmit(u);
                            db.SubmitChanges();
                        }
                        else
                        {
                            return Json(new { result = "error", message = "Sorry, a user account already exists with that email address" });
                        }
                    }
                    catch (Exception e)
                    {
                        //log error
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect!");
            }
            //return View();
            return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
        }

        private bool IsValid(string email, string password)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();
                bool IsValid = false;

                using (var db = new UnitBookingDataContext())
                {
                    //Retrieve the first user with the email provided
                    var user = db.Users.FirstOrDefault(u => u.Email == email);

                    //If the user exists check if the password provided matches the store password after hashing
                    if (user != null)
                    {
                        // Store the user temporarily in the context for this request.
                        System.Web.HttpContext.Current.Items.Add("User", user);

                        if (user.Password == crypto.Compute(password, user.PasswordSalt))
                        {
                            //If the credentials provided are correct return true indicating the login was valid
                            IsValid = true;
                        }
                    }
                    else
                    {
                        //If the credentials were invalid return false indicating the credentials were invalid
                        IsValid = false;
                    }
                }
                return IsValid;
            }
            catch (Exception e)
            {
                return false;
                //Log error
            }
        }
        
    }
}
