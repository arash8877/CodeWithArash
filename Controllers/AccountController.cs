using System;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;
using CodeWithArash.Data.Repositories;

namespace CodeWithArash.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            if (_userRepository.IsUserExist(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "User already exists!");
                return View(register);
            }

            Users user = new Users()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false,
                RegisterTime = DateTime.Now
            };

            _userRepository.AddUser(user); // Ensure SaveChanges() is called inside

            // Redirect with email as query param
            return RedirectToAction("RegisterSuccess", new { email = register.Email });
        }

        [HttpGet]
        public IActionResult RegisterSuccess(string email)
        {
            var model = new RegisterViewModel { Email = email };
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
