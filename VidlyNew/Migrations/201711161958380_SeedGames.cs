namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGames : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games(Name, NumberInStock, NumberAvailable, ReleaseDate, DateAdded, GenreId) VALUES('Battlefield 1', 5, 5, '10/14/2016', '11/16/2017', 1)");
            Sql("INSERT INTO Games(Name, NumberInStock, NumberAvailable, ReleaseDate, DateAdded, GenreId) VALUES('Battlefield 4', 4, 4, '10/14/2015', '11/16/2017', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
