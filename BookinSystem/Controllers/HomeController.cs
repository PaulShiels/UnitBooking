using BookinSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JsAction;

namespace BookinSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult login(UserModel viewModel)
        //{
        //    if (!ModelState.IsValid && viewModel != null)
        //    {
        //        //UserModel vm = new UserModel();
        //        //return View(vm);
        //        ModelState.AddModelError("", "Login data is incorrect!");
        //        //return new EmptyResult(); //RedirectToAction("Index", "Home");
        //    }
                

        //    return View(viewModel);
        //    //return RedirectToAction("Index", "Home");
        //}

        [JsAction()]
        public JsonResult login()
        {
            if (ModelState.IsValid)
            {
                //navigate to logged in page
                return Json("true");
            }
            else
                return Json("false");
        }
    }
}
