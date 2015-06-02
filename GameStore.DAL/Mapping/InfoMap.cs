using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class InfoMap : EntityTypeConfiguration<InfoEntity>
    {
        public InfoMap()
        {
            HasKey(i => i.Id);

          
            Property(i => i.Address).IsRequired();
            Property(i => i.Email).IsRequired();
            Property(i => i.Name).IsRequired();
            Property(i => i.Surname).IsRequired();
        }
    }
}
