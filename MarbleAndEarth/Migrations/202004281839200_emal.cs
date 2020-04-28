namespace MarbleAndEarth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "CustomerEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "CustomerEmail");
        }
    }
}
