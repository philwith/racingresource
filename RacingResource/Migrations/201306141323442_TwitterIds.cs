namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwitterIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Horses", "TwitterId", c => c.String());
            AddColumn("dbo.Trainers", "TwitterId", c => c.String());
            AddColumn("dbo.Jockeys", "TwitterId", c => c.String());
            AddColumn("dbo.Courses", "TwitterId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "TwitterId");
            DropColumn("dbo.Jockeys", "TwitterId");
            DropColumn("dbo.Trainers", "TwitterId");
            DropColumn("dbo.Horses", "TwitterId");
        }
    }
}
