namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class addedGiantBombandBGGidstogamemodel : DbMigration
	{
		public override void Up()
		{
			AddColumn("dbo.Game", "GiantBombID", c => c.Int(nullable: false));
			AddColumn("dbo.Game", "BGGID", c => c.Int(nullable: false));
		}

		public override void Down()
		{
			DropColumn("dbo.Game", "BGGID");
			DropColumn("dbo.Game", "GiantBombID");
		}
	}
}