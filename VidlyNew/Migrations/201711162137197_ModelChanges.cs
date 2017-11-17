namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "NumberInStock", c => c.Byte());
        }
    }
}
