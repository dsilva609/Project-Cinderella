namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedImageUrlpropertytobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ImageUrl", c => c.String());
            AddColumn("dbo.Game", "ImageUrl", c => c.String());
            AddColumn("dbo.Movie", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "ImageUrl");
            DropColumn("dbo.Game", "ImageUrl");
            DropColumn("dbo.Book", "ImageUrl");
        }
    }
}
