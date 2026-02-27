using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IS413_ToDoList.Models;
using Task = IS413_ToDoList.Models.Task;

namespace IS413_ToDoList.Controllers;

public class HomeController : Controller
{
    private ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Quadrants()
    {
        var tasks = _repo.GetAllTasks();
        return View(tasks);
    }

    public IActionResult AddEditTask(int? id)
    {
        var task = new Models.Task();
        if (id == null)
        {
            return View(task);
        }
        else
        {
            task = _repo.GetTaskById(id.Value);
            return View(task);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
