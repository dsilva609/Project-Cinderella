namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcheckedoutfieldtobaseitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "CheckedOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.Book", "CheckedOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.Game", "CheckedOut", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movie", "CheckedOut", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "CheckedOut");
            DropColumn("dbo.Game", "CheckedOut");
            DropColumn("dbo.Book", "CheckedOut");
            DropColumn("dbo.Album", "CheckedOut");
        }
    }
}
