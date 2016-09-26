namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtimescompletedtobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "TimesCompleted", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "TimesCompleted", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "TimesCompleted", c => c.Int(nullable: false));
            AddColumn("dbo.Movie", "TimesCompleted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "TimesCompleted");
            DropColumn("dbo.Game", "TimesCompleted");
            DropColumn("dbo.Book", "TimesCompleted");
            DropColumn("dbo.Album", "TimesCompleted");
        }
    }
}
