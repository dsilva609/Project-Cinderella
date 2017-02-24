namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedwishmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wish",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        UserID = c.String(nullable: false),
                        ApiID = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ItemType = c.Int(nullable: false),
                        Notes = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wish");
        }
    }
}
