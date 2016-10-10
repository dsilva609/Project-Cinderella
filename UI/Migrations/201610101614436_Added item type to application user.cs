namespace UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeditemtypetoapplicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Type");
        }
    }
}
