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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
  