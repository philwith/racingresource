namespace RacingResource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Website", c => c.String(maxLength: 100));
            AddColumn("dbo.Addresses", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.Addresses", "Telephone", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "Telephone");
            DropColumn("dbo.Addresses", "Email");
            DropColumn("dbo.Addresses", "Website");
        }
    }
}
