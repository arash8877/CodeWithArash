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



}
