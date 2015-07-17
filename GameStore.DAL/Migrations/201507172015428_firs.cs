namespace GameStore.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class firs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartEntities",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
                        IsInCart = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PublisherEntities", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.GameImageEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GameId = c.Guid(nullable: false),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.OrderEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        DeliveryAddress = c.String(),
                        ContactEmail = c.String(),
                        ContactPhone = c.String(),
                        OrderDate = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
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
                "dbo.CommentEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PostId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostEntities", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PostEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TopicId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 128),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        UserName = c.String(nullable: false),
                        GameEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TopicEntities", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.GameEntities", t => t.GameEntity_Id)
                .Index(t => t.TopicId)
                .Index(t => t.UserId)
                .Index(t => t.GameEntity_Id);
            
            CreateTable(
                "dbo.TopicEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false),
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
                        UserId = c.String(nullable: false, maxLength: 128),
                        Author = c.String(),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        Score = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
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
                "dbo.OrderEntityGameEntities",
                c => new
                    {
                        OrderEntity_Id = c.Guid(nullable: false),
                        GameEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderEntity_Id, t.GameEntity_Id })
                .ForeignKey("dbo.OrderEntities", t => t.OrderEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameEntities", t => t.GameEntity_Id, cascadeDelete: true)
                .Index(t => t.OrderEntity_Id)
                .Index(t => t.GameEntity_Id);
            
            CreateTable(
                "dbo.CartEntityGameEntities",
                c => new
                    {
                        CartEntity_UserId = c.String(nullable: false, maxLength: 128),
                        GameEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CartEntity_UserId, t.GameEntity_Id })
                .ForeignKey("dbo.CartEntities", t => t.CartEntity_UserId, cascadeDelete: true)
                .ForeignKey("dbo.GameEntities", t => t.GameEntity_Id, cascadeDelete: true)
                .Index(t => t.CartEntity_UserId)
                .Index(t => t.GameEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CartEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.CartEntityGameEntities", "CartEntity_UserId", "dbo.CartEntities");
            DropForeignKey("dbo.GameEntities", "PublisherId", "dbo.PublisherEntities");
            DropForeignKey("dbo.SupportEntities", "PublisherId", "dbo.PublisherEntities");
            DropForeignKey("dbo.PostEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewEntities", "GameId", "dbo.GameEntities");
            DropForeignKey("dbo.OrderEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InfoEntities", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentEntities", "PostId", "dbo.PostEntities");
            DropForeignKey("dbo.PostEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PostEntities", "TopicId", "dbo.TopicEntities");
            DropForeignKey("dbo.TopicEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartEntities", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.OrderEntityGameEntities", "OrderEntity_Id", "dbo.OrderEntities");
            DropForeignKey("dbo.GameImageEntities", "GameId", "dbo.GameEntities");
            DropIndex("dbo.CartEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.CartEntityGameEntities", new[] { "CartEntity_UserId" });
            DropIndex("dbo.OrderEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.OrderEntityGameEntities", new[] { "OrderEntity_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SupportEntities", new[] { "PublisherId" });
            DropIndex("dbo.PublisherEntities", new[] { "Name" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ReviewEntities", new[] { "UserId" });
            DropIndex("dbo.ReviewEntities", new[] { "GameId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.InfoEntities", new[] { "User_Id" });
            DropIndex("dbo.TopicEntities", new[] { "UserId" });
            DropIndex("dbo.PostEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.PostEntities", new[] { "UserId" });
            DropIndex("dbo.PostEntities", new[] { "TopicId" });
            DropIndex("dbo.CommentEntities", new[] { "UserId" });
            DropIndex("dbo.CommentEntities", new[] { "PostId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "UserName" });
            DropIndex("dbo.OrderEntities", new[] { "UserId" });
            DropIndex("dbo.GameImageEntities", new[] { "GameId" });
            DropIndex("dbo.GameEntities", new[] { "PublisherId" });
            DropIndex("dbo.CartEntities", new[] { "UserId" });
            DropTable("dbo.CartEntityGameEntities");
            DropTable("dbo.OrderEntityGameEntities");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SupportEntities");
            DropTable("dbo.PublisherEntities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ReviewEntities");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.InfoEntities");
            DropTable("dbo.TopicEntities");
            DropTable("dbo.PostEntities");
            DropTable("dbo.CommentEntities");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.OrderEntities");
            DropTable("dbo.GameImageEntities");
            DropTable("dbo.GameEntities");
            DropTable("dbo.CartEntities");
        }
    }
}
