namespace CharityProject.Migrations
{
    using CharityProject.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CharityProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CharityProject.Models.ApplicationDbContext context)
        {

            //---------CREATE THE ADMIN AUTHENTICATION ROLE---------------------//
            string roleAdmin = "admin";
            string email = "admin@gmail.com";
            string pass = "abcd1234";

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser { Id = "2111", UserName = email, Email = email };
            manager.Create(user, pass);

            var rolestore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(rolestore);
            var identityRole = new IdentityRole { Name = roleAdmin };

            roleManager.Create(identityRole);
            manager.AddToRole(user.Id, roleAdmin);
        }



    }
}
