using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class PostMap : EntityTypeConfiguration<PostEntity>
    {
        public PostMap()
        {
            Property(p => p.Description).IsRequired().HasMaxLength(1000).HasColumnType("nvarchar");
            Property(p => p.Title);
            Property(p => p.VotesDown);
            Property(p => p.VotesDown);

            // Relationships
            HasMany(p => p.Comments).WithRequired(c => c.Post).HasForeignKey(c => c.PostId);
            
            HasOptional(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId);
            HasRequired(p => p.Game).WithMany(g => g.Posts).HasForeignKey(p => p.GameId);

        }
    }
}
