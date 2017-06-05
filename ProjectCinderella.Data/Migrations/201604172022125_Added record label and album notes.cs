namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedrecordlabelandalbumnotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecordModel", "Notes", c => c.String());
            AddColumn("dbo.RecordModel", "RecordLabel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecordModel", "RecordLabel");
            DropColumn("dbo.RecordModel", "Notes");
        }
    }
}
