namespace SRAD_MVC.Migrations
{
    using SRAD_MVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SRAD_MVC.Models.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SRAD_MVC.Models.MainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.UserType.Count() == 0)
            {
                context.UserType.AddOrUpdate(x => x.Id,
                new UserType() { Type = "Student" },
                new UserType() { Type = "Admin" }          
                );
            }            
        }
    }
}
