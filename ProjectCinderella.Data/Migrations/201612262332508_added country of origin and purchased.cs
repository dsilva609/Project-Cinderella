namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcountryoforiginandpurchased : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "CountryOfOrigin", c => c.String());
            AddColumn("dbo.Album", "CountryPurchased", c => c.String());
            AddColumn("dbo.Book", "CountryOfOrigin", c => c.String());
            AddColumn("dbo.Book", "CountryPurchased", c => c.String());
            AddColumn("dbo.Game", "CountryOfOrigin", c => c.String());
            AddColumn("dbo.Game", "CountryPurchased", c => c.String());
            AddColumn("dbo.Movie", "CountryOfOrigin", c => c.String());
            AddColumn("dbo.Movie", "CountryPurchased", c => c.String());
            DropColumn("dbo.Game", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Country", c => c.String());
            DropColumn("dbo.Movie", "CountryPurchased");
            DropColumn("dbo.Movie", "CountryOfOrigin");
            DropColumn("dbo.Game", "CountryPurchased");
            DropColumn("dbo.Game", "CountryOfOrigin");
            DropColumn("dbo.Book", "CountryPurchased");
            DropColumn("dbo.Book", "CountryOfOrigin");
            DropColumn("dbo.Album", "CountryPurchased");
            DropColumn("dbo.Album", "CountryOfOrigin");
        }
    }
}
