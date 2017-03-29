namespace UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserNumtoidentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserNum");
        }
    }
}
