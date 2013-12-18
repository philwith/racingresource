namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveAndAlternateNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Horses", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trainers", "AlternateForename", c => c.String());
            AddColumn("dbo.Trainers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "IsActive");
            DropColumn("dbo.Trainers", "AlternateForename");
            DropColumn("dbo.Horses", "IsActive");
        }
    }
}
