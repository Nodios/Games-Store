namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewEntities", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewEntities", "Author");
        }
    }
}
