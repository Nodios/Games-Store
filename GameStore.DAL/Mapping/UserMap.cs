using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            HasKey(u => u.Id);

            Property(u => u.Username).IsRequired().HasMaxLength(50);

            //relationship constraints
            HasRequired(u => u.Info).WithOptional(i => i.User);
            HasOptional(u => u.Cart).WithRequired(c => c.User);

            HasMany(u => u.Games).WithMany(g => g.Users);

            

        }
    }
}
