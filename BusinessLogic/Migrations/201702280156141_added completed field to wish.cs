namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcompletedfieldtowish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wish", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wish", "Completed");
        }
    }
}
