namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                        NumberAvailable = c.Byte(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropTable("dbo.Games");
        }
    }
}
