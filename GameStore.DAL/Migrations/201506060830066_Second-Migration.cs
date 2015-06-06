namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.GameEntities", "Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GameEntities", new[] { "Name" });
        }
    }
}
