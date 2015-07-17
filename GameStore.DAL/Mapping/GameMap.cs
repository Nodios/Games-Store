using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class GameMap : EntityTypeConfiguration<GameEntity>
    {
        public GameMap()
        {
            Property(g => g.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Unique name
            Property(g => g.Name).IsRequired().HasMaxLength(50);

            Property(g => g.Description).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");
            Property(g => g.OsSupport).IsRequired().HasMaxLength(50);
            Property(g => g.ReviewScore);
            Property(g => g.Genre).IsRequired();
            Property(g => g.Price).IsRequired();
            Property(g => g.IsInCart).IsRequired();

            // Relation ship
            HasRequired(g => g.Publisher).WithMany(p => p.Games).HasForeignKey(g => g.PublisherId);
        }

       
    }
}
