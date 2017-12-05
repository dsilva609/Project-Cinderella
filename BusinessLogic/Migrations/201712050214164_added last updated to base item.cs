namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlastupdatedtobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "LastCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Book", "LastCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Game", "LastCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "LastCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.FunkoModel", "LastCompleted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FunkoModel", "LastCompleted");
            DropColumn("dbo.Movie", "LastCompleted");
            DropColumn("dbo.Game", "LastCompleted");
            DropColumn("dbo.Book", "LastCompleted");
            DropColumn("dbo.Album", "LastCompleted");
        }
    }
}
