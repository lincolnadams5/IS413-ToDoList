using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskModel = IS413_ToDoList.Models.Task;

// Models/TaskRepository.cs
namespace IS413_ToDoList.Models
{
    public class TaskRepository : ITaskRepository
    {
        private TaskDbContext _context;

        // Constructor - receives the DbContext via Dependency Injection
        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        // ---- TASK METHODS ----

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _context.Tasks
                .Include(t => t.Category)
                .ToList();
        }

        public TaskModel? GetTaskById(int id)
        {
            return _context.Tasks
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TaskId == id);
        }

        public void AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskModel task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        // ---- CATEGORY METHODS ----

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}