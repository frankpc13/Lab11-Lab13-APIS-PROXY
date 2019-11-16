using System.Runtime.InteropServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MVCAjaxDB;User Id=SA;Password=Kotoha13;");
        }

        public DbSet<Student> Students { get; set; }
        
    }
}