using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        ViewBag.Categories = _repo.GetAllCategories()
            .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName });

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

    [HttpPost]
    public IActionResult AddEditTask(Task task)
    {
        if (task.TaskId == 0)
            _repo.AddTask(task);
        else
            _repo.UpdateTask(task);

        TempData["Success"] = "Task saved successfully!";
        return RedirectToAction("Quadrants");
    }

    public IActionResult MarkComplete(int id)
    {
        var task = _repo.GetTaskById(id);
        if (task != null)
        {
            task.Completed = true;
            _repo.UpdateTask(task);
        }
        return RedirectToAction("Quadrants");
    }

    public IActionResult Delete(int id)
    {
        _repo.DeleteTask(id);
        return RedirectToAction("Quadrants");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}
