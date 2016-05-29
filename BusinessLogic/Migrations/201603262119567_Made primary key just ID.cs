namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class MadeprimarykeyjustID : DbMigration
	{
		public override void Up()
		{
			DropPrimaryKey("dbo.RecordModel");
			AlterColumn("dbo.RecordModel", "AlbumName", c => c.String());
			AlterColumn("dbo.RecordModel", "Artist", c => c.String());
			AddPrimaryKey("dbo.RecordModel", "ID");
		}

		public override void Down()
		{
			DropPrimaryKey("dbo.RecordModel");
			AlterColumn("dbo.RecordModel", "Artist", c => c.String(nullable: false, maxLength: 128));
			AlterColumn("dbo.RecordModel", "AlbumName", c => c.String(nullable: false, maxLength: 128));
			AddPrimaryKey("dbo.RecordModel", new[] { "AlbumName", "Artist", "MediaType" });
		}
	}
}