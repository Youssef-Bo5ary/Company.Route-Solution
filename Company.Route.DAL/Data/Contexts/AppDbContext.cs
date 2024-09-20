using Company.Route.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.DAL.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>  option) : base() //chaining for a parameter connected directly to DB
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);//because this line will run this onmodel
                                               //and the model in the base I have inherited from
                                            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = . ; Database= Companymvc; Trusted_Connection= True ; TrustServerCertificate=True");
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }
       // public DbSet<IdentityUser>Users { get; set; }
        
    }
}
