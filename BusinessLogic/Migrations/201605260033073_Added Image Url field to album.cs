namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageUrlfieldtoalbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Album", "ImageUrl");
        }
    }
}
