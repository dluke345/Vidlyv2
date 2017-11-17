namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'22741e9d-0f31-4617-ae2b-e7c30aef6cf9', N'dluke345@gmail.com', 0, N'AMP0xd317sD8JO9aCUFysFT0a1kJIsv9VOm9Zb9Ak3rjxFipiIVY/7P5/2jDisUM8g==', N'e0990496-114a-4e94-bf65-8dd9d39a90dc', NULL, 0, 0, NULL, 1, 0, N'dluke345@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ee5e44fc-b33f-4212-b606-d3594f396691', N'user@gmail.com', 0, N'AGnIRDx/HR/iRCU5Eb+nkyMpzWKIXmc9vqx6R/QTUOKBENdl4ZjYRYKWRSKOEwhQNw==', N'150d74bd-f669-4ea5-8e94-f54d413400ea', NULL, 0, 0, NULL, 1, 0, N'user@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c71fe463-5e2f-4189-a3e3-5aae7c02c8f9', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22741e9d-0f31-4617-ae2b-e7c30aef6cf9', N'c71fe463-5e2f-4189-a3e3-5aae7c02c8f9')");
        }
        
        public override void Down()
        {
        }
    }
}

