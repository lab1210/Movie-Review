﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie_App.Models;
using Movie_App.Service;



namespace Movie_App.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly RegisterService registerService;
        private readonly LoginService loginService;

        public AuthenticationController()
        {
            registerService = new RegisterService();
            loginService = new LoginService();

        }
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Logins login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    loginService.CheckUser(login);
                    if ((login.Role == "Admin"))
                    {
                        return RedirectToAction("MovieList", "Movie");

                    }
                    return RedirectToAction("TvSeries", "Home");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
               


            }
            return View(login);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registers register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    register.Role = "User";

                    registerService.AddUser(register);
                    return RedirectToAction("Login", "Authentication");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);

                }

            }
            return View(register);
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            loginService.clearLoginName();
            return RedirectToAction("TvSeries", "Home");
        }
    }
}