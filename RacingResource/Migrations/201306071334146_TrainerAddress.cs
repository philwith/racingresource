namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "AddressId", c => c.Int());
            AddForeignKey("dbo.Trainers", "AddressId", "dbo.Addresses", "Id");
            CreateIndex("dbo.Trainers", "AddressId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Trainers", new[] { "AddressId" });
            DropForeignKey("dbo.Trainers", "AddressId", "dbo.Addresses");
            DropColumn("dbo.Trainers", "AddressId");
        }
    }
}
