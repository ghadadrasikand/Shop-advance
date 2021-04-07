using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Host.Models;
using Shop.Host.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Contexts
{
    public class ShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
      ApplicationUserRole, IdentityUserLogin<string>,
      IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<ApplicationRole>().ToTable("Role");

            builder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = "90fd80f1-22fd-41ac-abfb-d7f8ff4c829a",
                Name = "ApplicationUser",
                NormalizedName = "APPLICATIONUSER"
            },
            new ApplicationRole
            {
                Id = "caf502dc-060e-4126-98a0-1d556a432167",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            );


            builder.Entity<ApplicationUserRole>().HasKey(x => x.Id);


            builder.Entity<ApplicationUserRole>()
                .HasOne(u => u.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(fk => fk.UserId);


            builder.Entity<ApplicationUserRole>()
                .HasOne(u => u.Role)
                .WithMany(r => r.ApplicationUserRole)
                .HasForeignKey(fk => fk.RoleId);

            builder.Entity<ApplicationUserRole>().ToTable("UserRole");

            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("data source=.;initial catalog=ShopDB;integrated security=true");
        //}
    }
}
