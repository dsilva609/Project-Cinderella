namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGameModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Developer = c.String(),
                        Publisher = c.String(nullable: false),
                        Genre = c.String(),
                        Type = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        MediaType = c.Int(nullable: false),
                        Platform = c.Int(nullable: false),
                        IsDLC = c.Boolean(nullable: false),
                        PartOfSeries = c.Boolean(nullable: false),
                        Series = c.String(),
                        YearReleased = c.Int(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                        Country = c.String(),
                        LocationPurchased = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        Language = c.String(),
                        Notes = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
        }
    }
}
