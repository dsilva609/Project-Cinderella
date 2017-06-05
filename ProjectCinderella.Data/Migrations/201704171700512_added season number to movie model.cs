namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedseasonnumbertomoviemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movie", "SeasonNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movie", "SeasonNumber");
        }
    }
}
