namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcategoryfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Category", c => c.String());
            AddColumn("dbo.Book", "Category", c => c.String());
            AddColumn("dbo.Game", "Category", c => c.String());
            AddColumn("dbo.Movie", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "Category");
            DropColumn("dbo.Game", "Category");
            DropColumn("dbo.Book", "Category");
            DropColumn("dbo.Album", "Category");
        }
    }
}
