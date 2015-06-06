using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class GameMap : EntityTypeConfiguration<GameEntity>
    {
        public GameMap()
        {
            HasKey(g => g.Id);
           
            // Unique name
            Property(g => g.Name).IsRequired().HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute()));


            Property(g => g.Description).IsRequired().HasMaxLength(500).HasColumnType("nvarchar");
            Property(g => g.OsSupport).IsRequired().HasMaxLength(50);
            Property(g => g.ReviewScore);

            // Relation ship
            HasRequired(g => g.Publisher).WithMany(p => p.Games).HasForeignKey(g => g.PublisherId);
        }

       
    }
}
