using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group3_9Project.Models
{
    public class TaskEntry
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Task is a required field.")]
        public string Task { get; set; }
        public string DueDate { get; set; }
        [Required(ErrorMessage = "Quadrant is a required field. Enter as a whole number between 1 and 4. e.g '3'")]
        public byte Quadrant { get; set; }

        public bool Completed { get; set; }
        // foreign key relationship
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
