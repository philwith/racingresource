namespace RacingResource.Migrations
{
    using RacingResource.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RacingResource.Models.RacingResourceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RacingResource.Models.RacingResourceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.GoingDescriptions.AddOrUpdate(
              g => g.Name,
              new GoingDescription { Name = "Heavy" },
              new GoingDescription { Name = "Soft" },
              new GoingDescription { Name = "Good to Soft" },
              new GoingDescription { Name = "Good" },
              new GoingDescription { Name = "Good to Firm" },
              new GoingDescription { Name = "Firm" },
              new GoingDescription { Name = "Hard" }
            );
            
        }
    }
}
