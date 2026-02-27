using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IS413_ToDoList.Models;
using Task = IS413_ToDoList.Models.Task;

namespace IS413_ToDoList.Controllers;

public class HomeController : Controller
{
    private TaskDbContext _context;
    private TaskRepository repo;
    
    public HomeController(TaskDbContext temp)
    {
        _context = temp;
        repo = new TaskRepository(_context);
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Quadrants()
    {
        IEnumerable<Task> tasks = repo.GetAllTasks();
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
            task = repo.GetTaskById(id.Value);
            return View(task);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
