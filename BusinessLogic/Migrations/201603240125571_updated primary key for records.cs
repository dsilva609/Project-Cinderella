namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class updatedprimarykeyforrecords : DbMigration
	{
		public override void Up()
		{
			//DropPrimaryKey("dbo.RecordModel");
			AlterColumn("dbo.RecordModel", "ID", c => c.Int(nullable: false));
			AlterColumn("dbo.RecordModel", "AlbumName", c => c.String(nullable: false));
			AlterColumn("dbo.RecordModel", "Artist", c => c.String(nullable: false));
			//AddPrimaryKey("dbo.RecordModel", new[] { "AlbumName", "Artist", "MediaType" });
		}

		public override void Down()
		{
			//DropPrimaryKey("dbo.RecordModel");
			AlterColumn("dbo.RecordModel", "Artist", c => c.String(nullable: false));
			AlterColumn("dbo.RecordModel", "AlbumName", c => c.String(nullable: false));
			AlterColumn("dbo.RecordModel", "ID", c => c.Int(nullable: false, identity: true));
			//AddPrimaryKey("dbo.RecordModel", "ID");
		}
	}
}