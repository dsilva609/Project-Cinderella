namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtracklisttoalbum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tracklist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        duration = c.String(),
                        position = c.String(),
                        type_ = c.String(),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .Index(t => t.AlbumID);
            
            CreateTable(
                "dbo.Extraartist",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        join = c.String(),
                        name = c.String(),
                        anv = c.String(),
                        tracks = c.String(),
                        role = c.String(),
                        resource_url = c.String(),
                        Tracklist_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tracklist", t => t.Tracklist_ID)
                .Index(t => t.Tracklist_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracklist", "AlbumID", "dbo.Album");
            DropForeignKey("dbo.Extraartist", "Tracklist_ID", "dbo.Tracklist");
            DropIndex("dbo.Extraartist", new[] { "Tracklist_ID" });
            DropIndex("dbo.Tracklist", new[] { "AlbumID" });
            DropTable("dbo.Extraartist");
            DropTable("dbo.Tracklist");
        }
    }
}
