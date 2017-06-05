namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbookmodelfrombasemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "YearReleased", c => c.Int(nullable: false));
            DropColumn("dbo.Book", "YearPublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "YearPublished", c => c.Int(nullable: false));
            DropColumn("dbo.Book", "YearReleased");
        }
    }
}
