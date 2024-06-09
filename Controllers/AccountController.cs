using Microsoft.AspNetCore.Mvc;
using UserLogin.Models;
using Microsoft.AspNetCore.Http;

namespace UserLogin.Controllers
{
    public class AccountController : Controller
    {
        private const string HardcodedUsername = "admin";
        private const string HardcodedPassword = "123";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == HardcodedUsername && model.Password == HardcodedPassword)
                {
                    HttpContext.Session.SetString("Username", model.Username);
                    TempData["Message"] = "Login successful!";
                    TempData["MessageType"] = "success";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "Invalid username or password";
                    TempData["MessageType"] = "error";
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
