namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedimageurltowishmidel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wish", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wish", "ImageUrl");
        }
    }
}
