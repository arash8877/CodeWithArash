using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeWithArash.Data
{
  public class CodeWithArashContext : DbContext // DbContext is a class from Entity Framework Core that represents a session with the database and allows querying and saving data.
  {
    public CodeWithArashContext(DbContextOptions<CodeWithArashContext> options) : base(options)
    {
    }

    public DbSet<Models.Category> Categories { get; set; } // DbSet create a table in db for Category model
    public DbSet<Models.Product> Products { get; set; } // DbSet create a table in db for Product model
    public DbSet<Models.BasketItem> BasketItems { get; set; } // DbSet create a table in db for BasketItem model
    public DbSet<Models.ProductInCategories> ProductInCategories { get; set; } // DbSet create a table in db for ProductInCategories model
    public DbSet<Models.Users> Users { get; set; } // DbSet create a table in db for Users model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Models.ProductInCategories>()
          .HasKey(i => new { i.ProductId, i.CategoryId }); // composite primary key

      modelBuilder.Entity<Models.BasketItem>() // one to one relationship between BasketItem and Product
          .HasOne(b => b.Product)
          .WithOne(p => p.BasketItem)
          .HasForeignKey<Models.BasketItem>(b => b.Id);

      // The "money" type is only for SQL Server.
      // modelBuilder.Entity<Models.BasketItem>() // configure Price property to use "money" data type in the database
      //     .Property(b => b.Price)
      //     .HasColumnType("money");


      #region Seed Data for Category Table

      modelBuilder.Entity<Models.Category>().HasData(new Models.Category
      {
        Id = 1,
        Name = "ASP .NET Core 9",
        Description = "All about ASP .NET Core and C# programming"
      }, new Models.Category
      {
        Id = 2,
        Name = "JavaScript",
        Description = "All about JavaScript programming"
      }, new Models.Category
      {
        Id = 3,
        Name = "Python",
        Description = "All about Python programming"
      }, new Models.Category
      {
        Id = 4,
        Name = "Machine Learning",
        Description = "All about Machine Learning"
      }
      );

      modelBuilder.Entity<Models.BasketItem>().HasData(new Models.BasketItem
      {
        Id = 1,
        Price = 100M,
        QuantityInStock = 1
      },
      new Models.BasketItem
      {
        Id = 2,
        Price = 200,
        QuantityInStock = 3
      }, new Models.BasketItem
      {
        Id = 3,
        Price = 300,
        QuantityInStock = 5
      }
      );

      modelBuilder.Entity<Models.Product>().HasData(new Models.Product
      {
        Id = 1,
        BasketItemId = 1,
        Name = "ASP .NET Core 9 - Beginner to Advanced",
        Description = "This course is designed to take you from a beginner to an advanced level in ASP .NET Core 9 development. You will learn the fundamentals of ASP .NET Core, including MVC architecture, Razor Pages, Entity Framework Core, and more. By the end of this course, you will have the skills and knowledge to build robust web applications using ASP .NET Core 9.",
      }, new Models.Product
      {
        Id = 2,
        BasketItemId = 2,
        Name = "JavaScript - The Complete Guide",
        Description = "This course is a comprehensive guide to JavaScript programming. You will learn the fundamentals of JavaScript, including variables, data types, functions, and control flow. You will also learn advanced topics such as object-oriented programming, asynchronous programming, and working with APIs. By the end of this course, you will have the skills and knowledge to build dynamic web applications using JavaScript.",
      }, new Models.Product
      {
        Id = 3,
        BasketItemId = 3,
        Name = "Python for Data Science and Machine Learning",
        Description = "This course is designed to teach you how to use Python for data science and machine learning. You will learn the fundamentals of Python programming, including data structures, functions, and libraries such as NumPy and Pandas. You will also learn how to use machine learning algorithms and techniques to analyze and visualize data. By the end of this course, you will have the skills and knowledge to work with data and build machine learning models using Python.",
      }
      );

      modelBuilder.Entity<Models.ProductInCategories>().HasData(
         new Models.ProductInCategories { ProductId = 1, CategoryId = 1 },
         // Product 2 only in Category 2
         new Models.ProductInCategories { ProductId = 2, CategoryId = 2 },
         new Models.ProductInCategories { ProductId = 2, CategoryId = 3 },
         // Product 3 only in Category 3 and 4
         new Models.ProductInCategories { ProductId = 3, CategoryId = 3 },
         new Models.ProductInCategories { ProductId = 3, CategoryId = 4 }


      );

      #endregion

      base.OnModelCreating(modelBuilder);
    }
  }
}
