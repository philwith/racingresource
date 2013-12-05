namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBhaIdToMeetingPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetingPages", "BhaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeetingPages", "BhaId");
        }
    }
}
