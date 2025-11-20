using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoApp
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todo => Set<Todo>();

        // Sobrescrever
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = c:\\sqlite\\db\\ada.db");

            base.OnConfiguring(optionsBuilder);
        }

    }
}