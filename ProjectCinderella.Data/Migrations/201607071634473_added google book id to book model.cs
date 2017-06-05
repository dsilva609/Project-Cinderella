namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgooglebookidtobookmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "GoogleBookID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "GoogleBookID");
        }
    }
}
