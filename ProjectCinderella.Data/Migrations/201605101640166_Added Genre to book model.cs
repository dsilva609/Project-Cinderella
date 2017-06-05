namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenretobookmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Genre");
        }
    }
}
