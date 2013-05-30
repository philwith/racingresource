namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jockey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jockeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        UKHR_JockeyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateIndex("dbo.Jockeys", new string[] { "Name", "UKHR_JockeyID" }, true, "IX_Name_UKHR_JockeyID");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jockeys", "IX_Name_UKHR_JockeyID");
            DropTable("dbo.Jockeys");
        }
    }
}
