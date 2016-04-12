namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Madeuseridrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecordModel", "UserID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecordModel", "UserID", c => c.String());
        }
    }
}
