namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGoingToRace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "Going", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Races", "Going");
        }
    }
}
