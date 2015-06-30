using GameStore.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping 
{
    public class CartMap : EntityTypeConfiguration<CartEntity>
    {
        public CartMap()
        {
            // key
           // HasKey(c => c.Id);

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        
            // One to one
            HasRequired(c => c.User).WithOptional(u => u.Cart);

            // Many to many
            HasMany(c => c.Games).WithMany(g => g.Carts);
        }


        
    }
}
