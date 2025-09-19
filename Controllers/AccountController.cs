using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;
using Microsoft.EntityFrameworkCore;
using CodeWithArash.Data;
using CodeWithArash.Data.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeWithArash.Controllers;

public class AccountController : Controller
{
  private IUserRepository _userRepository;
  public AccountController(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Register(RegisterViewModel register)
  {
    if (!ModelState.IsValid)
    {
      // Save to database
      return View(register);
    }
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

    _userRepository.AddUser(user);
  }

  return View();



}
