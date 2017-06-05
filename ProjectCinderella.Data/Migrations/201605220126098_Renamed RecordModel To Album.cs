namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedRecordModelToAlbum : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecordModel", newName: "Album");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Album", newName: "RecordModel");
        }
    }
}
