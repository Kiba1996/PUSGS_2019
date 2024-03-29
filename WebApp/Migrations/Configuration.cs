namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!"), Activated= true, Role="Admin" };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }

            if(!context.PassengerTypes.Any(u=> u.Name == "Student"))
            {
                var p = new PassengerType("Student");
                context.PassengerTypes.Add(p);

            }
            if (!context.PassengerTypes.Any(u => u.Name == "Retiree"))
            {
                var p = new PassengerType("Retiree");
                context.PassengerTypes.Add(p);

            }
            if (!context.PassengerTypes.Any(u => u.Name == "Regular"))
            {
                var p = new PassengerType("Regular");
                context.PassengerTypes.Add(p);

            }

            if (!context.DayTypes.Any(u => u.Name == "WorkDay"))
            {
                var p = new DayType("WorkDay");
                context.DayTypes.Add(p);

            }
            if (!context.DayTypes.Any(u => u.Name == "Saturday"))
            {
                var p = new DayType("Saturday");
                context.DayTypes.Add(p);

            }
            if (!context.DayTypes.Any(u => u.Name == "Sunday"))
            {
                var p = new DayType("Sunday");
                context.DayTypes.Add(p);

            }


            if (!context.TicketTypes.Any(u => u.Name == "Hourly"))
            {
                var p = new TicketType("Hourly");
                context.TicketTypes.Add(p);

            }
            if (!context.TicketTypes.Any(u => u.Name == "Daily"))
            {
                var p = new TicketType("Daily");
                context.TicketTypes.Add(p);

            }
            if (!context.TicketTypes.Any(u => u.Name == "Monthly"))
            {
                var p = new TicketType("Monthly");
                context.TicketTypes.Add(p);

            }
            if (!context.TicketTypes.Any(u => u.Name == "Yearly"))
            {
                var p = new TicketType("Yearly");
                context.TicketTypes.Add(p);

            }

        }
    }
}
