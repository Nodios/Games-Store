using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class CommentMap : EntityTypeConfiguration<CommentEntity>
    {
        public CommentMap()
        {
           // HasKey(c => c.Id);


            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Description).IsRequired();
            Property(c => c.VotesDown);
            Property(c => c.VotesUp);           
        }
    }
}
