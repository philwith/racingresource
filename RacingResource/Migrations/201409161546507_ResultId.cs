namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "BhaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "BhaId");
        }
    }
}
