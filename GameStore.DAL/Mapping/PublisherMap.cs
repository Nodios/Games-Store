using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class PublisherMap : EntityTypeConfiguration<PublisherEntity>
    {
        public PublisherMap()
        {
         //   HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Description).IsRequired().HasMaxLength(1000).HasColumnType("nvarchar");

            // Uniquename
            Property(c => c.Name).IsRequired().HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));

            // One to one
            HasOptional(c => c.Support).WithRequired(s => s.Publisher);

            //Many to one
            HasMany(c => c.Games).WithRequired(g => g.Publisher);
        }
    }
}
