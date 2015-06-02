using GameStore.DAL.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
namespace GameStore.DAL
{
    public interface IGamesStoreContext : IDisposable
    {
        DbSet<CartEntity> Carts { get; set; }
        DbSet<CommentEntity> Comments { get; set; }
        DbSet<GameEntity> Games { get; set; }
        DbSet<InfoEntity> Info { get; set; }
        DbSet<PostEntity> Posts { get; set; }
        DbSet<CompanyEntity> Publishers { get; set; }
        DbSet<ReviewEntity> Reviews { get; set; }
        DbSet<SupportEntity> Support { get; set; }
        DbSet<UserEntity> Users { get; set; }

        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}
