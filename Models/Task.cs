using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IS413_ToDoList.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string? TaskName { get; set; }
        public DateTime? Duedate { get; set; }
        public string? Quadrant { get; set; }
        //Foreign Key
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool Completed { get; set; } = false;

    }
}
