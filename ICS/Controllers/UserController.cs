using ICS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ICS.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(ICS.Models.USER user)
        {
            if (ModelState.IsValid)
            {
                if (Isvalid(user.cUserName, user.cPassword))
                {
                    FormsAuthentication.SetAuthCookie(user.cUserName, false);
                    return RedirectToAction("Index", "Home");

                }
                else 
                {
                    ModelState.AddModelError("", "Login data id incorrect");

                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(ICS.Models.USER user)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        private bool Isvalid(string username, string password)
        {
            var SimpleCrypto = new SimpleCrypto.PBKDF2();

            bool isvalid = false;

            using (var db = new ICSContext())
            {
                var user = db.USERS.FirstOrDefault(u => u.cUserName == username);

                if (user != null)
                {
                    //if (user.cPassword == SimpleCrypto.Compute(password))
                    if (user.cPassword == password)
                    {
                        isvalid = true;
                    }
                }
            }

            return isvalid;
        }

    }
}
