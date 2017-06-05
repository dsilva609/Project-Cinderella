namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedextraartistsfromtracklist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Extraartist", "Tracklist_ID", "dbo.Tracklist");
            DropIndex("dbo.Extraartist", new[] { "Tracklist_ID" });
            DropTable("dbo.Extraartist");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Extraartist", "Tracklist_ID");
            AddForeignKey("dbo.Extraartist", "Tracklist_ID", "dbo.Tracklist", "ID");
        }
    }
}
