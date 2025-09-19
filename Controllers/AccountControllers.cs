using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CodeWithArash.Models;
using Microsoft.EntityFrameworkCore;
using CodeWithArash.Data;

namespace CodeWithArash.Controllers;

public class AccountControllers : Controller
{
  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Register(RegisterViewModel register)
  {
    if (ModelState.IsValid)
    {
      // Save to database
      return RedirectToAction("Index", "Home");
    }
    return View(register);
  }



}
