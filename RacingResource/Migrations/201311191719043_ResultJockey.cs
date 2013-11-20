namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultJockey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Jockey_Id", c => c.Int());
            AddForeignKey("dbo.Results", "Jockey_Id", "dbo.Jockeys", "Id");
            CreateIndex("dbo.Results", "Jockey_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Results", new[] { "Jockey_Id" });
            DropForeignKey("dbo.Results", "Jockey_Id", "dbo.Jockeys");
            DropColumn("dbo.Results", "Jockey_Id");
        }
    }
}
