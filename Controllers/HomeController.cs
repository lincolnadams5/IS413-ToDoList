using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IS413_ToDoList.Models;

namespace IS413_ToDoList.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Quadrants()
    {
        return View();
    }

    public IActionResult AddEditTask()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
