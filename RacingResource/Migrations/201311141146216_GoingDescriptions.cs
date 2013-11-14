namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoingDescriptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoingDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Races", "Going_Id", c => c.Int());
            AddForeignKey("dbo.Races", "Going_Id", "dbo.GoingDescriptions", "Id");
            CreateIndex("dbo.Races", "Going_Id");
            DropColumn("dbo.Races", "Going");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Races", "Going", c => c.String());
            DropIndex("dbo.Races", new[] { "Going_Id" });
            DropForeignKey("dbo.Races", "Going_Id", "dbo.GoingDescriptions");
            DropColumn("dbo.Races", "Going_Id");
            DropTable("dbo.GoingDescriptions");
        }
    }
}
