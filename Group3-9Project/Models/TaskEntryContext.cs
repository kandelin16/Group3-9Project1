using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3_9Project.Models
{
    public class TaskEntryContext : DbContext
    {
        public TaskEntryContext(DbContextOptions<TaskEntryContext> options) : base(options)
        {
            //blank for now
        }
        //public DbSet<TaskEntryContext> Tasks { get; set; }
        public DbSet<TaskEntry> TaskEntries { get; set; } // not totally sure on this part
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );
            mb.Entity<TaskEntry>().HasData(
                new TaskEntry
                {
                    TaskId = 1,
                    Task = "Mission 6",
                    DueDate = "February 9, 2022",
                    Quadrant = 1,
                    CategoryId = 2,
                    Completed = false
                }
                );
        }
    }
}
