namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offtime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Races", "OffTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Races", "OffTime", c => c.Time(nullable: false));
        }
    }
}
