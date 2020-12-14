namespace BOL.Migrations
{
    using BOL.Domain;
    using BOL.Enum;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BOL.DbContext.SetServiceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BOL.DbContext.SetServiceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (!roleManager.RoleExists(UserRoles.Admin.ToString()))
            {
                var adminRole = new IdentityRole
                {
                    Name = UserRoles.Admin.ToString()
                };
                roleManager.Create(adminRole);
                var adminUser = new User
                {
                    Name = "Rezvan",
                    Family = "Rezvani",
                    Email = "Rezvan@gmail.com",
                    PhoneNumber = "090000000",
                    NationalCode = "00000000000",
                    UserName = "Rezvan",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                
                };
                var result = userManager.Create(adminUser, "1234");
                if (result.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, UserRoles.Admin.ToString());
                }

            }
            if (!roleManager.RoleExists(UserRoles.Customer.ToString()))
            {
                roleManager.Create(new IdentityRole { Name = UserRoles.Customer.ToString() });
          
            }

            context.SaveChanges();
        }
    }
}
