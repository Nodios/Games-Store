using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class CommentMap : EntityTypeConfiguration<CommentEntity>
    {
        public CommentMap()
        {
            HasKey(c => c.Id);

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Description).IsRequired().HasMaxLength(1000);
            Property(c => c.UserName).IsRequired();

            HasRequired(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
            HasRequired(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
        }
    }
}
