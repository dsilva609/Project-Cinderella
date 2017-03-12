namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstyletoalbummodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Style", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "Style");
        }
    }
}
