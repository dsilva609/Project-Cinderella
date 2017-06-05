namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedISBN10and13tobookmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ISBN10", c => c.String());
            AddColumn("dbo.Book", "ISBN13", c => c.String());
            DropColumn("dbo.Book", "ISBN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "ISBN", c => c.String());
            DropColumn("dbo.Book", "ISBN13");
            DropColumn("dbo.Book", "ISBN10");
        }
    }
}
