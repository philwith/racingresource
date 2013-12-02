namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeetingPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResultPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        BhaRid = c.Int(nullable: false),
                        BhaCid = c.Int(nullable: false),
                        MeetingPage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeetingPages", t => t.MeetingPage_Id)
                .Index(t => t.MeetingPage_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ResultPages", new[] { "MeetingPage_Id" });
            DropForeignKey("dbo.ResultPages", "MeetingPage_Id", "dbo.MeetingPages");
            DropTable("dbo.ResultPages");
            DropTable("dbo.MeetingPages");
        }
    }
}
