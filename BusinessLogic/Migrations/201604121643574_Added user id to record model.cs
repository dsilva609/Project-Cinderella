namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeduseridtorecordmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecordModel", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecordModel", "UserID");
        }
    }
}
