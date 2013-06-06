namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BHAHorseInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Horses", "Nationality", c => c.String());
            AddColumn("dbo.Horses", "Sex", c => c.String());
            AddColumn("dbo.Horses", "FlatRating", c => c.Int(nullable: false));
            AddColumn("dbo.Horses", "AWRating", c => c.Int(nullable: false));
            AddColumn("dbo.Horses", "ChaseRating", c => c.Int(nullable: false));
            AddColumn("dbo.Horses", "HurdleRating", c => c.Int(nullable: false));
            AddColumn("dbo.Horses", "SireId", c => c.Int());
            AddColumn("dbo.Horses", "DamId", c => c.Int());
            AddForeignKey("dbo.Horses", "SireId", "dbo.Horses", "Id");
            AddForeignKey("dbo.Horses", "DamId", "dbo.Horses", "Id");
            CreateIndex("dbo.Horses", "SireId");
            CreateIndex("dbo.Horses", "DamId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Horses", new[] { "DamId" });
            DropIndex("dbo.Horses", new[] { "SireId" });
            DropForeignKey("dbo.Horses", "DamId", "dbo.Horses");
            DropForeignKey("dbo.Horses", "SireId", "dbo.Horses");
            DropColumn("dbo.Horses", "DamId");
            DropColumn("dbo.Horses", "SireId");
            DropColumn("dbo.Horses", "HurdleRating");
            DropColumn("dbo.Horses", "ChaseRating");
            DropColumn("dbo.Horses", "AWRating");
            DropColumn("dbo.Horses", "FlatRating");
            DropColumn("dbo.Horses", "Sex");
            DropColumn("dbo.Horses", "Nationality");
        }
    }
}
