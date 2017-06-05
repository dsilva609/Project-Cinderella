namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateRecordModelToMakeAlbumNameAndArtistRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecordModel", "AlbumName", c => c.String(nullable: false));
            AlterColumn("dbo.RecordModel", "Artist", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.RecordModel", "Artist", c => c.String());
            AlterColumn("dbo.RecordModel", "AlbumName", c => c.String());
        }
    }
}