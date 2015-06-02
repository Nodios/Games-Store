using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class GameMap : EntityTypeConfiguration<GameEntity>
    {
        public GameMap()
        {
            HasKey(g => g.Id);

         
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            Property(g => g.Description).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");
            Property(g => g.OsSupport).IsRequired().HasMaxLength(50);
            Property(g => g.ReviewScore);
          
        }

       
    }
}
