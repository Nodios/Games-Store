using System.Data.Entity.ModelConfiguration;
using GameStore.DAL.Models;

namespace GameStore.DAL.Mapping 
{
    public class CartMap : EntityTypeConfiguration<CartEntity>
    {
        public CartMap()
        {
            // key
            HasKey(c => c.Id);
        
            // One to one
            HasRequired(c => c.User).WithOptional(u => u.Cart);

            // Many to many
            HasMany(c => c.Games).WithMany(g => g.Carts);
        }


        
    }
}
