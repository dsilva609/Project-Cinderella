namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpagecounttobooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "PageCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "PageCount");
        }
    }
}
