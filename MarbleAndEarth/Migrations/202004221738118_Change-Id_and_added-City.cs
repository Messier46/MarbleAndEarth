namespace MarbleAndEarth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeId_and_addedCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ShippingCity", c => c.String());
            AlterColumn("dbo.Purchases", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "ShippingCity");
        }
    }
}
