namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcompletionstatustobasemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "CompletionStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "CompletionStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "CompletionStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "CompletionStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "CompletionStatus");
            DropColumn("dbo.Game", "CompletionStatus");
            DropColumn("dbo.Book", "CompletionStatus");
            DropColumn("dbo.Album", "CompletionStatus");
        }
    }
}
