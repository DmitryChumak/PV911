using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Role adminRole = new Role { RoleId = 1, Name = "admin" };
            Role userRole = new Role { RoleId = 2, Name = "user" };

            User admin = new User {Id = 1, Email = "admin@gmail.com", Password = "qwerty", RoleId = 1 };

            builder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            builder.Entity<User>().HasData(new User[] { admin });
            base.OnModelCreating(builder);

        }
    }
}
