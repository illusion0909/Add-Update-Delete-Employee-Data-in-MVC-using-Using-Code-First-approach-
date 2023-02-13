using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DotNet_Project05.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("cn")
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}