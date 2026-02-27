using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;
using TaskModel = IS413_ToDoList.Models.Task;

namespace IS413_ToDoList.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public ICollection<TaskModel>? Tasks {  get; set; }
    }
}
