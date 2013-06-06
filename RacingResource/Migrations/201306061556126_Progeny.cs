namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Progeny : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Horses", "YearOfBirth", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Horses", "YearOfBirth", c => c.Int(nullable: false));
        }
    }
}
