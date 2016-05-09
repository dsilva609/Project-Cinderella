namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Media = c.Int(nullable: false),
                        Hardcover = c.Boolean(nullable: false),
                        Publisher = c.String(nullable: false),
                        YearPublished = c.Int(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                        LocationPurchased = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        ISBN = c.String(),
                        IsReissue = c.Boolean(nullable: false),
                        Language = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}
