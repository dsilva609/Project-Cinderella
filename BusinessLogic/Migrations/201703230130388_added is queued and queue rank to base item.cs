namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedisqueuedandqueueranktobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "IsQueued", c => c.Boolean(nullable: false));
            AddColumn("dbo.Album", "QueueRank", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "IsQueued", c => c.Boolean(nullable: false));
            AddColumn("dbo.Book", "QueueRank", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "IsQueued", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "QueueRank", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "IsQueued", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movie", "QueueRank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "QueueRank");
            DropColumn("dbo.Movie", "IsQueued");
            DropColumn("dbo.Game", "QueueRank");
            DropColumn("dbo.Game", "IsQueued");
            DropColumn("dbo.Book", "QueueRank");
            DropColumn("dbo.Book", "IsQueued");
            DropColumn("dbo.Album", "QueueRank");
            DropColumn("dbo.Album", "IsQueued");
        }
    }
}
