namespace UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddefaultactiontype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DefaultType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DefaultAction_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "DefaultAction_Value", c => c.String());
            DropColumn("dbo.AspNetUsers", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "DefaultAction_Value");
            DropColumn("dbo.AspNetUsers", "DefaultAction_Name");
            DropColumn("dbo.AspNetUsers", "DefaultType");
        }
    }
}
