using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Tarea6_4.Models;

namespace Tarea6_4.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();

        public ActionResult Index()
        {
           return View();
        }


        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.login() == true)
                {
                    session.setSession("userName", datos.Username);
                    ViewBag.User = session.getSession("userName");
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public async Task<ActionResult> SinIn()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> SinIn(SigIn datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Signin() == false)
                {
                    ViewBag.Message = "El usuario o Email ya esta registrado";
                    return View("SignIn", datos);
                }
                else
                {
                    return RedirectToAction("Usuarios", "Home");
                }
            }
            else
            {
                return View("SignIn");
            }
        }
    }
}