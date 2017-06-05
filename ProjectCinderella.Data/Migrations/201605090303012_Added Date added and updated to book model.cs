namespace BusinessLogic.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class AddedDateaddedandupdatedtobookmodel : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Book", "DateAdded", c => c.DateTime(nullable: true));
			AddColumn("dbo.Book", "DateUpdated", c => c.DateTime(nullable: true));
		}

		public override void Down()
		{
			DropColumn("dbo.Book", "DateUpdated");
			DropColumn("dbo.Book", "DateAdded");
		}
	}
}