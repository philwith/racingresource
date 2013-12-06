namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewJockeySchema : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jockeys", "IX_Name_UKHR_JockeyID");
            AddColumn("dbo.Jockeys", "Initials", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Jockeys", "Forenames", c => c.String(maxLength: 255));
            AddColumn("dbo.Jockeys", "Surname", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Jockeys", "LicenceType", c => c.String(maxLength: 255));
            AlterColumn("dbo.Jockeys", "TwitterId", c => c.String(maxLength: 15));
            AlterColumn("dbo.MeetingPages", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Jockeys", "Name");
            DropColumn("dbo.Jockeys", "UKHR_JockeyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jockeys", "UKHR_JockeyID", c => c.Int(nullable: false));
            AddColumn("dbo.Jockeys", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.MeetingPages", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Jockeys", "TwitterId", c => c.String());
            DropColumn("dbo.Jockeys", "LicenceType");
            DropColumn("dbo.Jockeys", "Surname");
            DropColumn("dbo.Jockeys", "Forenames");
            DropColumn("dbo.Jockeys", "Initials");
            CreateIndex("dbo.Jockeys", new string[] { "Name", "UKHR_JockeyID" }, true, "IX_Name_UKHR_JockeyID");
        }
    }
}
