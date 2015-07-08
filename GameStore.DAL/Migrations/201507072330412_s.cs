namespace GameStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cart_Games", newName: "CartEntityGameEntities");
            RenameColumn(table: "dbo.CartEntityGameEntities", name: "Cart_FK", newName: "CartEntity_UserId");
            RenameColumn(table: "dbo.CartEntityGameEntities", name: "Game_FK", newName: "GameEntity_Id");
            RenameIndex(table: "dbo.CartEntityGameEntities", name: "IX_Cart_FK", newName: "IX_CartEntity_UserId");
            RenameIndex(table: "dbo.CartEntityGameEntities", name: "IX_Game_FK", newName: "IX_GameEntity_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CartEntityGameEntities", name: "IX_GameEntity_Id", newName: "IX_Game_FK");
            RenameIndex(table: "dbo.CartEntityGameEntities", name: "IX_CartEntity_UserId", newName: "IX_Cart_FK");
            RenameColumn(table: "dbo.CartEntityGameEntities", name: "GameEntity_Id", newName: "Game_FK");
            RenameColumn(table: "dbo.CartEntityGameEntities", name: "CartEntity_UserId", newName: "Cart_FK");
            RenameTable(name: "dbo.CartEntityGameEntities", newName: "Cart_Games");
        }
    }
}
