namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedspeedtoalbummodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "Speed", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "Speed");
        }
    }
}
