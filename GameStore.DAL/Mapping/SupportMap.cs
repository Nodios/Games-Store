using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class SupportMap : EntityTypeConfiguration<SupportEntity>
    {
        public SupportMap()
        {
            HasKey(s => s.PublisherId);

            Property(s => s.Address).IsRequired().HasMaxLength(200);
            Property(s => s.Email).IsRequired().HasMaxLength(50);
            Property(s => s.Phone);

        }
    }
}
