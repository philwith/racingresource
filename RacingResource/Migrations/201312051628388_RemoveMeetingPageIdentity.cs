namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMeetingPageIdentity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MeetingPages", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MeetingPages", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
