namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMoreGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES ('Adventure')");
            Sql("INSERT INTO Genres(Name) VALUES ('Role-playing')");
            Sql("INSERT INTO Genres(Name) VALUES ('Simulation')");
            Sql("INSERT INTO Genres(Name) VALUES ('Strategy')");
            Sql("INSERT INTO Genres(Name) VALUES ('Sports')");
            Sql("INSERT INTO Genres(Name) VALUES ('MOBA')");
        }
        
        public override void Down()
        {
        }
    }
}
