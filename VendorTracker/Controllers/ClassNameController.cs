using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Template.Models;

namespace Template.Controllers
{
  public class ClassNameController : Controller
  {
    [HttpGet("/class-controller")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost("/class-controller")]
    public ActionResult IndexView()
    {
      return RedirectToAction("Index");
    }
  }

}