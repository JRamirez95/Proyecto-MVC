using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dodge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;



namespace Dodge.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //[ResponseCache(Duration = 1)]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Home()
        {
            //if (Session.isSingin)
            //{
                return View();
            //}
            //else
            //{
            //    return RedirectToAction(nameof(Index));
            //}
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private readonly DodgeContext _context;

        public HomeController(DodgeContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> up(string username, string password)
        {


            if (username == null && password == null)
            {
                TempData["Error"] = "* Invalid Credentiales *";
                //return RedirectToAction(nameof(HomeController.Login), "Home");
            }

            var user = await _context.User.SingleOrDefaultAsync(u => u.userName == username);

            if (user != null)
            {
                if (user.userName == username && user.password == password)
                {
                    if (user.job == "Manager")
                    {
                        Session.isSingin = true;
                        Session.isAdmin = "Manager".Equals(user.job) ? true : false;
                        Session.user = user.name + " " + user.lastName;
                        return RedirectToAction(nameof(Home));
                    }
                    else if (user.job == "Employee")
                    {
                        Session.isSingin = true;
                        Session.isAdmin = "Employee".Equals(user.job) ? false : true;
                        Session.user = user.name + " " + user.lastName;
                        return RedirectToAction(nameof(Home));
                    }
                }
                else if (user.userName != username)
                {
                    TempData["Error"] = "* Invalid Credentiales *";
                }
                else if (user.password != password)
                {
                    TempData["Error"] = "* Invalid Credentiales *";
                }
            }
            else
            {
                TempData["Error"] = "* Unregistered user *";
            }

            return RedirectToAction(nameof(Login));
        }

       
        public IActionResult logout()
        {
            Session.isSingin = false;
            return RedirectToAction(nameof(Index));

        }

    }
}
