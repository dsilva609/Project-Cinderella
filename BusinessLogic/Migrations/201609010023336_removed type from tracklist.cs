namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtypefromtracklist : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tracklist", "type_");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracklist", "type_", c => c.String());
        }
    }
}
