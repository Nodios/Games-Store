using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class GameImageMap : EntityTypeConfiguration<GameImageEntity>
    {
        public GameImageMap()
        {
            Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Content).IsRequired();

            HasRequired(i => i.Game).WithMany(g => g.GameImages).HasForeignKey(i => i.GameId);
        }
    }
}
