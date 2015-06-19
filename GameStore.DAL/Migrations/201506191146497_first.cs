namespace GameStore.DAL.Migrations
{
    using System;
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Id)
                .Index(t => t.Id);
            
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
                        UserId = c.Guid(),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserId)
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
                        UserEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostEntities", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_Id)
                .Index(t => t.PostId)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.InfoEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GameId = c.Guid(nullable: false),
                        Score = c.Single(nullable: false),
                        UserEntity_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_Id)
                .Index(t => t.GameId)
                .Index(t => t.UserEntity_Id);
            
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
                "dbo.UserEntityGameEntities",
                c => new
                    {
                        UserEntity_Id = c.Guid(nullable: false),
                        GameEntity_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserEntity_Id, t.GameEntity_Id })
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_Id, cascadeDelete: true)
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
            DropForeignKey("dbo.CartEntities", "Id", "dbo.UserEntities");
            DropForeignKey("dbo.CartEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.CartEntityGameEntities", "CartEntity_Id", "dbo.CartEntities");
            DropForeignKey("dbo.GameEntities", "PublisherId", "dbo.PublisherEntities");
            DropForeignKey("dbo.SupportEntities", "PublisherId", "dbo.PublisherEntities");
            DropForeignKey("dbo.PostEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.ReviewEntities", "UserEntity_Id", "dbo.UserEntities");
            DropForeignKey("dbo.ReviewEntities", "GameId", "dbo.GameEntities");
            DropForeignKey("dbo.UserEntities", "Id", "dbo.InfoEntities");
            DropForeignKey("dbo.UserEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.UserEntityGameEntities", "UserEntity_Id", "dbo.UserEntities");
            DropForeignKey("dbo.CommentEntities", "UserEntity_Id", "dbo.UserEntities");
            DropForeignKey("dbo.PostEntities", "GameId", "dbo.GameEntities");
            DropForeignKey("dbo.CommentEntities", "PostId", "dbo.PostEntities");
            DropIndex("dbo.CartEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.CartEntityGameEntities", new[] { "CartEntity_Id" });
            DropIndex("dbo.UserEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.UserEntityGameEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.SupportEntities", new[] { "PublisherId" });
            DropIndex("dbo.PublisherEntities", new[] { "Name" });
            DropIndex("dbo.ReviewEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.ReviewEntities", new[] { "GameId" });
            DropIndex("dbo.UserEntities", new[] { "Id" });
            DropIndex("dbo.CommentEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.CommentEntities", new[] { "PostId" });
            DropIndex("dbo.PostEntities", new[] { "UserId" });
            DropIndex("dbo.PostEntities", new[] { "GameId" });
            DropIndex("dbo.GameEntities", new[] { "Name" });
            DropIndex("dbo.GameEntities", new[] { "PublisherId" });
            DropIndex("dbo.CartEntities", new[] { "Id" });
            DropTable("dbo.CartEntityGameEntities");
            DropTable("dbo.UserEntityGameEntities");
            DropTable("dbo.SupportEntities");
            DropTable("dbo.PublisherEntities");
            DropTable("dbo.ReviewEntities");
            DropTable("dbo.InfoEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.CommentEntities");
            DropTable("dbo.PostEntities");
            DropTable("dbo.GameEntities");
            DropTable("dbo.CartEntities");
        }
    }
}
