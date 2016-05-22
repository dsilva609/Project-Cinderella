namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscogsIDtoalbummodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "DiscogsID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "DiscogsID");
        }
    }
}
