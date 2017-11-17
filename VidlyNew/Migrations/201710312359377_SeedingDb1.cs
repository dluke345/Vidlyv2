namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingDb1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Pay As You Go', 10, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Monthly', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Quaterly', 100, 3, 20)");
            Sql("INSERT INTO MembershipTypes (Name, SignUpFee, DurationInMonths, DiscountRate) VALUES ('Yearly', 300, 12, 30)");

            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsLetter, BirthDate, MembershipTypeId) VALUES ('David Luke', 1, '6/26/1988', 4)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsLetter, BirthDate, MembershipTypeId) VALUES ('Grant Looney', 0, '6/26/1988', 1)");


            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");


            Sql("INSERT INTO Movies (Name, GenreId, MovieReleaseDate, MovieDateAdded, NumberInStock) VALUES ('Hangover', 2, '6/26/1988', '10/31/2017', 4)");
            Sql("INSERT INTO Movies (Name, GenreId, MovieReleaseDate, MovieDateAdded, NumberInStock) VALUES ('blah', 3, '6/26/1988', '10/31/2017', 4)");
            Sql("INSERT INTO Movies (Name, GenreId, MovieReleaseDate, MovieDateAdded, NumberInStock) VALUES ('poop', 4, '6/26/1988', '10/31/2017', 4)");
            Sql("INSERT INTO Movies (Name, GenreId, MovieReleaseDate, MovieDateAdded, NumberInStock) VALUES ('Hangfdgdggover', 2, '6/26/1988', '10/31/2017', 4)");

        }

        public override void Down()
        {
        }
    }
}
