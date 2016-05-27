namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedprimarykeyforrecords : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RecordModel");
            AlterColumn("dbo.RecordModel", "releaseID", c => c.Int(nullable: false));
            AlterColumn("dbo.RecordModel", "AlbumName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.RecordModel", "Artist", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.RecordModel", new[] { "AlbumName", "Artist", "MediaType" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RecordModel");
            AlterColumn("dbo.RecordModel", "Artist", c => c.String(nullable: false));
            AlterColumn("dbo.RecordModel", "AlbumName", c => c.String(nullable: false));
            AlterColumn("dbo.RecordModel", "releaseID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RecordModel", "releaseID");
        }
    }
}
