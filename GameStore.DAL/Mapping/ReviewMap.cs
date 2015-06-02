using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class ReviewMap : EntityTypeConfiguration<ReviewEntity>
    {
        public ReviewMap()
        {
            Property(r => r.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.Score);

            // One to many
            HasRequired(r => r.Game).WithMany(g => g.Reviews).HasForeignKey(r => r.FKGame);
        }

      
    }

}
