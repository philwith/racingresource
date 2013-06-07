namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropIndex : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Horses", "IX_Name_UKHR_HorseID");
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Horses", new string[] { "Name", "UKHR_HorseID" }, true, "IX_Name_UKHR_HorseID");
        }
    }
}
