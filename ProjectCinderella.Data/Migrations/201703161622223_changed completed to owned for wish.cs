namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcompletedtoownedforwish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wish", "Owned", c => c.Boolean(nullable: false));
            DropColumn("dbo.Wish", "Completed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wish", "Completed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Wish", "Owned");
        }
    }
}
