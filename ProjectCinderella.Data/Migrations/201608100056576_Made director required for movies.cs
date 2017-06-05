namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Madedirectorrequiredformovies : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.Movie", "Director", c => c.String(nullable: false, defaultValueSql: "'NA'"));
		}

		public override void Down()
		{
			AlterColumn("dbo.Movie", "Director", c => c.String());
		}
	}
}