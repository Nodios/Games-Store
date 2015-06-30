namespace GameStore.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GameEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PublisherId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        OsSupport = c.String(nullable: false, maxLength: 50),
                        ReviewScore = c.Single(),
                        Genre = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublisherEntities", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.PostEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        GameId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PostId = c.Guid(nullable: false),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        UserEntity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostEntities", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserEntity_Id)
                .Index(t => t.PostId)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.InfoEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReviewEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GameId = c.Guid(nullable: false),
                        Score = c.Single(nullable: false),
                        UserEntity_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserEntity_Id)
                .Index(t => t.GameId)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PublisherEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.SupportEntities",
                c => new
                    {
                        PublisherId = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId)
                .ForeignKey("dbo.PublisherEntities", t => t.PublisherId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserEntityGameEntities",
                c => new
                    {
                        UserEntity_Id = c.String(nullable: false, maxLength: 128),
                        GameEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserEntity_Id, t.GameEntity_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.UserEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameEntities", t => t.GameEntity_Id, cascadeDelete: true)
                .Index(t => t.UserEntity_Id)
                .Index(t => t.GameEntity_Id);
            
            CreateTable(
                "dbo.CartEntityGameEntities",
                c => new
                    {
                        CartEntity_Id = c.Guid(nullable: false),
                        GameEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CartEntity_Id, t.GameEntity_Id })
                .ForeignKey("dbo.CartEntities", t => t.CartEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameEntities", t => t.GameEntity_Id, cascadeDelete: true)
                .Index(t => t.CartEntity_Id)
                .Index(t => t.GameEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CartEntities", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.CartEntityGameEntities", "CartEntity_Id", "dbo.CartEntities");
            DropForeignKey("dbo.GameEntities", "PublisherId", "dbo.PublisherEntities");
            DropForeignKey("dbo.SupportEntities", "PublisherId", "dbo.PublisherEntities");
            DropForeignKey("dbo.PostEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewEntities", "UserEntity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewEntities", "GameId", "dbo.GameEntities");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InfoEntities", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.UserEntityGameEntities", "UserEntity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentEntities", "UserEntity_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostEntities", "GameId", "dbo.GameEntities");
            DropForeignKey("dbo.CommentEntities", "PostId", "dbo.PostEntities");
            DropIndex("dbo.CartEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.CartEntityGameEntities", new[] { "CartEntity_Id" });
            DropIndex("dbo.UserEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.UserEntityGameEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SupportEntities", new[] { "PublisherId" });
            DropIndex("dbo.PublisherEntities", new[] { "Name" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ReviewEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.ReviewEntities", new[] { "GameId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.InfoEntities", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "UserName" });
            DropIndex("dbo.CommentEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.CommentEntities", new[] { "PostId" });
            DropIndex("dbo.PostEntities", new[] { "UserId" });
            DropIndex("dbo.PostEntities", new[] { "GameId" });
            DropIndex("dbo.GameEntities", new[] { "Name" });
            DropIndex("dbo.GameEntities", new[] { "PublisherId" });
            DropIndex("dbo.CartEntities", new[] { "User_Id" });
            DropTable("dbo.CartEntityGameEntities");
            DropTable("dbo.UserEntityGameEntities");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SupportEntities");
            DropTable("dbo.PublisherEntities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ReviewEntities");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.InfoEntities");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CommentEntities");
            DropTable("dbo.PostEntities");
            DropTable("dbo.GameEntities");
            DropTable("dbo.CartEntities");
        }
    }
}
