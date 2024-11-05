using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class AppDbContext: DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
public string DbPath { get; set; }
    protected AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Contacts.db");
        

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
                {
              Id= 1,
              FirstName = "Johnnn",
            LastName = "Doe",
            BirthDate = new DateOnly(2000, 12, 20),
            PhoneNumber = "333 444 555",
           // Email = @.com
                
                },
            new ContactEntity()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doooe",
                BirthDate = new DateOnly(2000, 12, 20),
                PhoneNumber = "222 333 444" ,
                
            }
            
                
        );
    }
}