namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateAddedAndDateUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecordModel", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.RecordModel", "DateUpdated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecordModel", "DateUpdated");
            DropColumn("dbo.RecordModel", "DateAdded");
        }
    }
}
