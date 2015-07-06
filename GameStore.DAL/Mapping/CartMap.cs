using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping 
{
    public class CartMap : EntityTypeConfiguration<CartEntity>
    {
        public CartMap()
        {
            HasKey(u => u.UserId);

            // Many to many
            HasMany(c => c.GamesInCart).WithMany(g => g.Carts);
        }


        
    }
}
