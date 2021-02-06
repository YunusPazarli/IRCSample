using IRCSample.Models;
using IRCSample.Models.ORM.Context;
using IRCSample.Models.ORM.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IRCSample.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRCContext _context;
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var chatUsers = _context.ChatUsers.FirstOrDefault(x => x.EMail == model.EMail && x.Password == model.Password);


                if (chatUsers != null)
                {
                    var claims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Email, model.EMail),
                    new Claim(ClaimTypes.Name,chatUsers.ID.ToString())
                };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);


                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "E-Mail or Password wrong!";
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
