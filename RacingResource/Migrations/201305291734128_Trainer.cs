namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trainer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        UKHR_TrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Horses", "Trainer_Id", c => c.Int());
            AddForeignKey("dbo.Horses", "Trainer_Id", "dbo.Trainers", "Id");
            CreateIndex("dbo.Horses", "Trainer_Id");
            CreateIndex("dbo.Trainers", new string[] { "Name", "UKHR_TrainerID" }, true, "IX_Name_UKHR_TrainerID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trainers", "IX_Name_UKHR_TrainerID");
            DropIndex("dbo.Horses", new[] { "Trainer_Id" });
            DropForeignKey("dbo.Horses", "Trainer_Id", "dbo.Trainers");
            DropColumn("dbo.Horses", "Trainer_Id");
            DropTable("dbo.Trainers");
        }
    }
}
