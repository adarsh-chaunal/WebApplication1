using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ToDo> ToDos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>().HasData(
            new ToDo { Id = 1, Item = "Tomato" },
            new ToDo { Id = 2, Item = "Onion" },
            new ToDo { Id = 3, Item = "Rice" },
            new ToDo { Id = 4, Item = "Cucumber" },
            new ToDo { Id = 5, Item = "Cheese" }
        );

    }

}
