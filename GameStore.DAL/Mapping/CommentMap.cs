using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class CommentMap : EntityTypeConfiguration<CommentEntity>
    {
        public CommentMap()
        {
            HasKey(c => c.Id);

            Property(c => c.Description).IsRequired();
            Property(c => c.VotesDown);
            Property(c => c.VotesUp);           
        }
    }
}
