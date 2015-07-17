using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class PostMap : EntityTypeConfiguration<PostEntity>
    {
        public PostMap()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Title).IsRequired().HasMaxLength(100);
            Property(p => p.Description).IsRequired().HasMaxLength(1000);
            Property(p => p.UserName).IsRequired();

            // Relationships
            HasMany(p => p.Comments).WithRequired(c => c.Post).HasForeignKey(c => c.PostId);
            HasRequired(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId);
            HasRequired(p => p.Topic).WithMany(t => t.Posts).HasForeignKey(p => p.TopicId);
 

        }
    }
}
