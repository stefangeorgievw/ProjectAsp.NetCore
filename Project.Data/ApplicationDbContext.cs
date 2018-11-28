using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

        public DbSet<CompanyProfile> CompaniesProfiles { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>()
                   .HasOne(a => a.CompanyProfile)
                   .WithOne(c => c.Account)
                   .HasForeignKey<CompanyProfile>(c => c.AccountId);

            builder.Entity<Account>()
                   .HasOne(a => a.UserProfile)
                   .WithOne(u => u.Account)
                   .HasForeignKey<UserProfile>(u => u.AccountId);


        }


    }
}
