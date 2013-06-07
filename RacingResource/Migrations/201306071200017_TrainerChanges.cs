namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Forename", c => c.String(maxLength: 255));
            AddColumn("dbo.Trainers", "Surname", c => c.String(maxLength: 255));
            AddColumn("dbo.Trainers", "LicenceType", c => c.String(maxLength: 255));
            AlterColumn("dbo.Trainers", "UKHR_TrainerID", c => c.Int());
            DropIndex("dbo.Trainers", "IX_Name_UKHR_TrainerID");
            DropColumn("dbo.Trainers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Name", c => c.String(maxLength: 255));
            CreateIndex("dbo.Trainers", new string[] { "Name", "UKHR_TrainerID" }, true, "IX_Name_UKHR_TrainerID");
            AlterColumn("dbo.Trainers", "UKHR_TrainerID", c => c.Int(nullable: false));
            DropColumn("dbo.Trainers", "LicenceType");
            DropColumn("dbo.Trainers", "Surname");
            DropColumn("dbo.Trainers", "Forename");
        }
    }
}
