namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mademodelsuseIsPhysicalformediatype : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Book", "Media");
            DropColumn("dbo.Game", "MediaType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "MediaType", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "Media", c => c.Int(nullable: false));
        }
    }
}
