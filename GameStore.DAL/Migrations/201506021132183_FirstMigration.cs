namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GameEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        OsSupport = c.String(nullable: false, maxLength: 50),
                        ReviewScore = c.Single(),
                        Publisher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEntities", t => t.Publisher_Id, cascadeDelete: true)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.PostEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        GameFK = c.Int(nullable: false),
                        UserFK = c.Int(),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.GameFK, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserFK)
                .Index(t => t.GameFK)
                .Index(t => t.UserFK);
            
            CreateTable(
                "dbo.CommentEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostFK = c.Int(nullable: false),
                        VotesUp = c.Int(nullable: false),
                        VotesDown = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        UserEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostEntities", t => t.PostFK, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_Id)
                .Index(t => t.PostFK)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InfoEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.InfoEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Id = c.Int(nullable: false, identity: true),
                        FKGame = c.Int(nullable: false),
                        Score = c.Single(nullable: false),
                        UserEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameEntities", t => t.FKGame, cascadeDelete: true)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_Id)
                .Index(t => t.FKGame)
                .Index(t => t.UserEntity_Id);
            
            CreateTable(
                "dbo.CompanyEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SupportEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SupportEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEntityGameEntities",
                c => new
                    {
                        UserEntity_Id = c.Int(nullable: false),
                        GameEntity_Id = c.Int(nullable: false),
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
                        CartEntity_Id = c.Int(nullable: false),
                        GameEntity_Id = c.Int(nullable: false),
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
            DropForeignKey("dbo.CompanyEntities", "Id", "dbo.SupportEntities");
            DropForeignKey("dbo.GameEntities", "Publisher_Id", "dbo.CompanyEntities");
            DropForeignKey("dbo.PostEntities", "UserFK", "dbo.UserEntities");
            DropForeignKey("dbo.ReviewEntities", "UserEntity_Id", "dbo.UserEntities");
            DropForeignKey("dbo.ReviewEntities", "FKGame", "dbo.GameEntities");
            DropForeignKey("dbo.UserEntities", "Id", "dbo.InfoEntities");
            DropForeignKey("dbo.UserEntityGameEntities", "GameEntity_Id", "dbo.GameEntities");
            DropForeignKey("dbo.UserEntityGameEntities", "UserEntity_Id", "dbo.UserEntities");
            DropForeignKey("dbo.CommentEntities", "UserEntity_Id", "dbo.UserEntities");
            DropForeignKey("dbo.PostEntities", "GameFK", "dbo.GameEntities");
            DropForeignKey("dbo.CommentEntities", "PostFK", "dbo.PostEntities");
            DropIndex("dbo.CartEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.CartEntityGameEntities", new[] { "CartEntity_Id" });
            DropIndex("dbo.UserEntityGameEntities", new[] { "GameEntity_Id" });
            DropIndex("dbo.UserEntityGameEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.CompanyEntities", new[] { "Id" });
            DropIndex("dbo.ReviewEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.ReviewEntities", new[] { "FKGame" });
            DropIndex("dbo.UserEntities", new[] { "Id" });
            DropIndex("dbo.CommentEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.CommentEntities", new[] { "PostFK" });
            DropIndex("dbo.PostEntities", new[] { "UserFK" });
            DropIndex("dbo.PostEntities", new[] { "GameFK" });
            DropIndex("dbo.GameEntities", new[] { "Publisher_Id" });
            DropIndex("dbo.CartEntities", new[] { "Id" });
            DropTable("dbo.CartEntityGameEntities");
            DropTable("dbo.UserEntityGameEntities");
            DropTable("dbo.SupportEntities");
            DropTable("dbo.CompanyEntities");
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
