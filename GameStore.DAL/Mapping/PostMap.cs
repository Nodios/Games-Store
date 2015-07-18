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
            Property(p => p.Description).IsRequired();
            Property(p => p.UserName).IsRequired();
            Property(p => p.Date).HasColumnType("datetime2");

            // Relationships
            HasMany(p => p.Comments).WithRequired(c => c.Post).HasForeignKey(c => c.PostId);
            HasRequired(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);
            HasRequired(p => p.Topic).WithMany(t => t.Posts).HasForeignKey(p => p.TopicId);
 

        }
    }
}
