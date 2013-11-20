namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendedDistanceLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "Distance", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Results", "Distance", c => c.String(maxLength: 10));
        }
    }
}
