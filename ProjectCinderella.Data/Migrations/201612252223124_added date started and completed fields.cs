namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatestartedandcompletedfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "DateStarted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Album", "DateCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Book", "DateStarted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Book", "DateCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Game", "DateStarted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Game", "DateCompleted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "DateStarted", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movie", "DateCompleted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "DateCompleted");
            DropColumn("dbo.Movie", "DateStarted");
            DropColumn("dbo.Game", "DateCompleted");
            DropColumn("dbo.Game", "DateStarted");
            DropColumn("dbo.Book", "DateCompleted");
            DropColumn("dbo.Book", "DateStarted");
            DropColumn("dbo.Album", "DateCompleted");
            DropColumn("dbo.Album", "DateStarted");
        }
    }
}
