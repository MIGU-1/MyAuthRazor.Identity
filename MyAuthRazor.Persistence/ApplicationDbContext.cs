using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyAuthRazor.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            Debug.Write(configuration);

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  base.OnModelCreating(modelBuilder);

          //  DateTime from = new DateTime(DateTime.Now.Year - 1, 1, 1);
          //  DateTime to = new DateTime(DateTime.Now.Year + 1, 12, 31);

          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 1, Name = "Test-Kampagne", From = new DateTime(2020, 12, 1), To = new DateTime(2099, 12, 31) });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 2, Name = "Antigentest Bildungsbereich (Burgenland)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 3, Name = "Antigentest Bildungsbereich (Kärnten)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 4, Name = "Antigentest Bildungsbereich (Niederösterreich)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 5, Name = "Antigentest Bildungsbereich (Oberösterreich)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 6, Name = "Antigentest Bildungsbereich (Salzburg)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 7, Name = "Antigentest Bildungsbereich (Steiermark)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 8, Name = "Antigentest Bildungsbereich (Tirol)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 9, Name = "Antigentest Bildungsbereich (Vorarlberg)", From = from, To = to });
          //  modelBuilder.Entity<Campaign>().HasData(new Campaign() { Id = 10, Name = "Antigentest Bildungsbereich (Wien)", From = from, To = to });

          //  modelBuilder.Entity<TestCenter>().HasData(new TestCenter() { Id = 1, Name = "Sporthalle Leonding", City = "Leonding", Postalcode = 4060, Street = "Ehrenfellnerstraße 9", SlotCapacity = 5 });
          //  modelBuilder.Entity<TestCenter>().HasData(new TestCenter() { Id = 2, Name = "Kulturzentrum Marchtrenk", City = "Marchtrenk", Postalcode = 4614, Street = "Rennerstraße 7", SlotCapacity = 3 });
          //  modelBuilder.Entity<TestCenter>().HasData(new TestCenter() { Id = 3, Name = "Design Center Linz", City = "Linz", Postalcode = 4020, Street = "Europaplatz 1", SlotCapacity = 10 });

          //  modelBuilder
          //    .Entity<Campaign>()
          //    .HasMany(c => c.AvailableTestCenters)
          //    .WithMany(t => t.AvailableInCampaigns)
          //    .UsingEntity(j => j.HasData(new[] {
          //new { AvailableInCampaignsId = 1, AvailableTestCentersId = 1 },
          //new { AvailableInCampaignsId = 1, AvailableTestCentersId = 2 },
          //new { AvailableInCampaignsId = 1, AvailableTestCentersId = 3 },
          //    }));

          //  modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Admin" });
          //  modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "User" });
          //  modelBuilder.Entity<User>().HasData(new User
          //  {
          //      Id = 1,
          //      RoleId = 1,
          //      Email = "admin@htl.at",
          //      Password = AuthUtils.GenerateHashedPassword("admin@htl.at")
          //  });
          //  modelBuilder.Entity<User>().HasData(new User
          //  {
          //      Id = 2,
          //      RoleId = 2,
          //      Email = "user@htl.at",
          //      Password = AuthUtils.GenerateHashedPassword("user@htl.at")
          //  });
        }
    }
}
