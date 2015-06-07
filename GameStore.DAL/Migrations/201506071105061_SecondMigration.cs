namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameEntities", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameEntities", "Genre", c => c.Int(nullable: false));
        }
    }
}
