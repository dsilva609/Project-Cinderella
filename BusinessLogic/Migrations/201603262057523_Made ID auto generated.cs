namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeIDautogenerated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecordModel", "ID", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecordModel", "ID", c => c.Int(nullable: false));
        }
    }
}
