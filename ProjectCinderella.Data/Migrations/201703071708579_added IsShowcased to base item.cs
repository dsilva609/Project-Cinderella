namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsShowcasedtobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "IsShowcased", c => c.Boolean(nullable: false));
            AddColumn("dbo.Book", "IsShowcased", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "IsShowcased", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movie", "IsShowcased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "IsShowcased");
            DropColumn("dbo.Game", "IsShowcased");
            DropColumn("dbo.Book", "IsShowcased");
            DropColumn("dbo.Album", "IsShowcased");
        }
    }
}
