﻿using GameStore.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace GameStore.DAL.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            //relationship constraints
            HasOptional(u => u.Info).WithRequired(i => i.User);
            HasOptional(u => u.Cart).WithRequired(c => c.User);
            HasMany(u => u.Games).WithMany(g => g.Users);

        }
    }
}
