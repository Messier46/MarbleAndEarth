namespace MarbleAndEarth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillOutPurchases : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "ShippingAddr", c => c.String());
            AddColumn("dbo.Purchases", "ShippingState", c => c.String());
            AddColumn("dbo.Purchases", "PayMethod", c => c.String());
            AlterColumn("dbo.Purchases", "ProductId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "PayMethod");
            DropColumn("dbo.Purchases", "ShippingState");
            DropColumn("dbo.Purchases", "ShippingAddr");
        }
    }
}
