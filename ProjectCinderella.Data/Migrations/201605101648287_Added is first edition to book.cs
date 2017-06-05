namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedisfirsteditiontobook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "IsFirstEdition", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "IsFirstEdition");
        }
    }
}
