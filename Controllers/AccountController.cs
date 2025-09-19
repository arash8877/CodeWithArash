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

    #region Register
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
    #endregion




    #region Login
    public IActionResult Login()
    {
      return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel login)
    {
      if (!ModelState.IsValid)
        return View(login);

      var user = _userRepository.GetUserForLogin(login.Email.ToLower(), login.Password);
      if (user == null)
      {
        ModelState.AddModelError("Email", "Email or Password is incorrect!");
        return View(login);}

      return RedirectToAction("Index", "Home");
    }
    #endregion



  }
}
