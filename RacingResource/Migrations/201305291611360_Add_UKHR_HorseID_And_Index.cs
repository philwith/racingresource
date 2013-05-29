namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UKHR_HorseID_And_Index : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Horses", "Name", c => c.String(maxLength: 255));
            CreateIndex("dbo.Horses", new string[] { "Name", "UKHR_HorseID" }, true, "IX_Name_UKHR_HorseID");
        }

        public override void Down()
        {
            DropIndex("dbo.Horses", "IX_Name_UKHR_HorseID");
            AlterColumn("dbo.Horses", "Name", c => c.String());
        }
    }
}
