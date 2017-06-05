namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class albumnowinheritsfrombaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Album", "Language", c => c.String());
            AddColumn("dbo.Album", "YearReleased", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "IsPhysical", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "IsPhysical", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movie", "IsPhysical", c => c.Boolean(nullable: false));
            DropColumn("dbo.Album", "AlbumName");
            DropColumn("dbo.Album", "AlbumYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Album", "AlbumYear", c => c.Int(nullable: false));
            AddColumn("dbo.Album", "AlbumName", c => c.String(nullable: false));
            DropColumn("dbo.Movie", "IsPhysical");
            DropColumn("dbo.Game", "IsPhysical");
            DropColumn("dbo.Book", "IsPhysical");
            DropColumn("dbo.Album", "YearReleased");
            DropColumn("dbo.Album", "Language");
            DropColumn("dbo.Album", "Title");
        }
    }
}
