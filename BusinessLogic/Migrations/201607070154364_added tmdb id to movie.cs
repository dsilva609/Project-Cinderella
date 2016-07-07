namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtmdbidtomovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "TMDBID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "TMDBID");
        }
    }
}
