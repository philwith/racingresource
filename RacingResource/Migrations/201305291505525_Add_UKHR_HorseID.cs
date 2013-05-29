namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UKHR_HorseID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Horses", "UKHR_HorseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Horses", "UKHR_HorseID");
        }
    }
}
