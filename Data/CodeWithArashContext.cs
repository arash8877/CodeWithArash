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

        // You can add more DbSet properties for other entities here
    }
}
  