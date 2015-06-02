using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<CompanyEntity>
    {
        public CompanyMap()
        {
            HasKey(c => c.Id);

            Property(c => c.Description).IsRequired().HasMaxLength(1000).HasColumnType("nvarchar");
            Property(c => c.Name).IsRequired().HasMaxLength(50);

            // One to one
            HasRequired(c => c.Support).WithOptional(s => s.Company);

            //Many to one
            HasMany(c => c.Games).WithRequired(g => g.Publisher);
        }
    }
}
