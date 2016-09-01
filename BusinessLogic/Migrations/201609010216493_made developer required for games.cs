namespace BusinessLogic.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class madedeveloperrequiredforgames : DbMigration
	{
		public override void Up()
		{
			AlterColumn("dbo.Game", "Developer", c => c.String(nullable: false, defaultValueSql: "'N/A'"));
		}

		public override void Down()
		{
			AlterColumn("dbo.Game", "Developer", c => c.String());
		}
	}
}