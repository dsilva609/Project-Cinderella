namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusernumtobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "UserNum", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "UserNum", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "UserNum", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "UserNum", c => c.Int(nullable: false));
            AddColumn("dbo.FunkoModel", "UserNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FunkoModel", "UserNum");
            DropColumn("dbo.Movie", "UserNum");
            DropColumn("dbo.Game", "UserNum");
            DropColumn("dbo.Book", "UserNum");
            DropColumn("dbo.Album", "UserNum");
        }
    }
}
