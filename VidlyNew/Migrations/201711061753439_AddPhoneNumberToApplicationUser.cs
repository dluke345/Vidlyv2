namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneNumberToApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {

        }
    }
}
