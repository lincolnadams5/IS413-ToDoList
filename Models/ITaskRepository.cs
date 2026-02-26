using Microsoft.AspNetCore.Mvc;
using TaskModel = IS413_ToDoList.Models.Task;

namespace IS413_ToDoList.Models
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
