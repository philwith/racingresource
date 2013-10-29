namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BHAIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "BhaRid", c => c.Int(nullable: false));
            AddColumn("dbo.Races", "BhaCid", c => c.Int(nullable: false));
            DropColumn("dbo.Meetings", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meetings", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Races", "BhaCid");
            DropColumn("dbo.Races", "BhaRid");
        }
    }
}
