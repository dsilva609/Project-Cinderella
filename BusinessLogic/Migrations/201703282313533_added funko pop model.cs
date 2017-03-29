namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfunkopopmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FunkoModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Series = c.String(nullable: false),
                        PopLine = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        UserID = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Genre = c.String(),
                        Language = c.String(),
                        Notes = c.String(),
                        ImageUrl = c.String(),
                        YearReleased = c.Int(nullable: false),
                        IsPhysical = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        LocationPurchased = c.String(),
                        DatePurchased = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        CompletionStatus = c.Int(nullable: false),
                        DateStarted = c.DateTime(nullable: false),
                        DateCompleted = c.DateTime(nullable: false),
                        CheckedOut = c.Boolean(nullable: false),
                        TimesCompleted = c.Int(nullable: false),
                        Category = c.String(),
                        CountryOfOrigin = c.String(),
                        CountryPurchased = c.String(),
                        IsShowcased = c.Boolean(nullable: false),
                        IsQueued = c.Boolean(nullable: false),
                        QueueRank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FunkoModel");
        }
    }
}
