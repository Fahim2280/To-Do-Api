using Microsoft.EntityFrameworkCore;
using To_do.Models;

namespace To_do.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems {get; set;}
    }
}
