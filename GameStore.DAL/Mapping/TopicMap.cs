using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    /// <summary>
    /// Mappings for topic entity
    /// </summary>
    public class TopicMap : EntityTypeConfiguration<TopicEntity>
    {
        public TopicMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.UserName).IsRequired();
            Property(t => t.Title).IsRequired().HasMaxLength(100);

            HasRequired(t => t.User).WithMany(u => u.Topics).HasForeignKey(t => t.UserId);
        }
    }
}
