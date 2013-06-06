namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedHorseSchema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Horses", "FlatRating", c => c.Int());
            AlterColumn("dbo.Horses", "AWRating", c => c.Int());
            AlterColumn("dbo.Horses", "ChaseRating", c => c.Int());
            AlterColumn("dbo.Horses", "HurdleRating", c => c.Int());
            AlterColumn("dbo.Horses", "UKHR_HorseID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Horses", "UKHR_HorseID", c => c.Int(nullable: false));
            AlterColumn("dbo.Horses", "HurdleRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Horses", "ChaseRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Horses", "AWRating", c => c.Int(nullable: false));
            AlterColumn("dbo.Horses", "FlatRating", c => c.Int(nullable: false));
        }
    }
}
