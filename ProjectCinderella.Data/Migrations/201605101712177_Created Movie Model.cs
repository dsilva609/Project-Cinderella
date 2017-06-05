namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class CreatedMovieModel : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Movie",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					UserID = c.String(nullable: false),
					Title = c.String(nullable: false),
					Director = c.String(),
					Genre = c.String(),
					Type = c.Int(nullable: false),
					Distributor = c.String(),
					IsNew = c.Boolean(nullable: false),
					Rating = c.Int(nullable: false),
					YearReleased = c.Int(nullable: false),
					Language = c.String(),
					Notes = c.String(),
					DatePurchased = c.DateTime(nullable: false),
					LocationPurchased = c.String(),
					DateAdded = c.DateTime(nullable: true),
					DateUpdated = c.DateTime(nullable: true),
				})
				.PrimaryKey(t => t.ID);
		}

		public override void Down()
		{
			DropTable("dbo.Movie");
		}
	}
}