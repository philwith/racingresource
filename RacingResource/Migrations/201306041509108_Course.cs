namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        UKHR_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            CreateIndex("dbo.Courses", new string[] { "Name", "UKHR_CourseID" }, true, "IX_Name_UKHR_CourseID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", "IX_Name_UKHR_CourseID");
            DropTable("dbo.Courses");
        }
    }
}
