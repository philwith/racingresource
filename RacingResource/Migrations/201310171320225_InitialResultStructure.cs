namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialResultStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        OffTime = c.Time(nullable: false),
                        Distance = c.Int(),
                        Prize = c.Int(),
                        RaceTypeId = c.Int(),
                        RaceGradeId = c.Int(),
                        Meeting_Id = c.Int(),
                        Feature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceTypes", t => t.RaceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.RaceGrades", t => t.RaceGradeId, cascadeDelete: true)
                .ForeignKey("dbo.Meetings", t => t.Meeting_Id)
                .ForeignKey("dbo.Features", t => t.Feature_Id, cascadeDelete: true)
                .Index(t => t.RaceTypeId)
                .Index(t => t.RaceGradeId)
                .Index(t => t.Meeting_Id)
                .Index(t => t.Feature_Id);
            
            CreateTable(
                "dbo.RaceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceGrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Horse_Id = c.Int(),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Horses", t => t.Horse_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Horse_Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Distance = c.String(maxLength: 10),
                        StartingPrice = c.Double(),
                        Weight = c.Int(),
                        Rating = c.Int(),
                        Horse_Id = c.Int(),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Horses", t => t.Horse_Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Horse_Id)
                .Index(t => t.Race_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Results", new[] { "Race_Id" });
            DropIndex("dbo.Results", new[] { "Horse_Id" });
            DropIndex("dbo.Entries", new[] { "Race_Id" });
            DropIndex("dbo.Entries", new[] { "Horse_Id" });
            DropIndex("dbo.Meetings", new[] { "Course_Id" });
            DropIndex("dbo.Races", new[] { "Feature_Id" });
            DropIndex("dbo.Races", new[] { "Meeting_Id" });
            DropIndex("dbo.Races", new[] { "RaceGradeId" });
            DropIndex("dbo.Races", new[] { "RaceTypeId" });
            DropForeignKey("dbo.Results", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Results", "Horse_Id", "dbo.Horses");
            DropForeignKey("dbo.Entries", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Entries", "Horse_Id", "dbo.Horses");
            DropForeignKey("dbo.Meetings", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Races", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.Races", "Meeting_Id", "dbo.Meetings");
            DropForeignKey("dbo.Races", "RaceGradeId", "dbo.RaceGrades");
            DropForeignKey("dbo.Races", "RaceTypeId", "dbo.RaceTypes");
            DropTable("dbo.Results");
            DropTable("dbo.Entries");
            DropTable("dbo.Features");
            DropTable("dbo.Meetings");
            DropTable("dbo.RaceGrades");
            DropTable("dbo.RaceTypes");
            DropTable("dbo.Races");
        }
    }
}
