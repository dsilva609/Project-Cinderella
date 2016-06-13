namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsizetoalbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Size", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "Size");
        }
    }
}
