using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class OrderMap : EntityTypeConfiguration<OrderEntity>
    {
        public OrderMap()
        {
            HasKey(o => o.Id);

            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(o => o.Name);
            HasRequired(o => o.Surname);
            HasRequired(o => o.UserId);
            HasRequired(o => o.ContactEmail);
            HasRequired(o => o.DeliveryAddress);

            HasMany(o => o.Games).WithMany(o => o.Orders);
            HasRequired(o => o.User).WithMany(u => u.Orders).HasForeignKey(o => o.UserId);
        }
    }
}
