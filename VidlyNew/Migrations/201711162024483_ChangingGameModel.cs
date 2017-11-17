namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingGameModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "NumberInStock", c => c.Byte());
            AlterColumn("dbo.Games", "ReleaseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "NumberInStock", c => c.Byte(nullable: false));
        }
    }
}
