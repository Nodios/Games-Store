using GameStore.DAL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
namespace GameStore.DAL
{
    /// <summary>
    /// Interface that provides method signatures for database context
    /// </summary>
    public interface IGamesStoreContext : IDisposable
    {
        DbSet<CartEntity> Carts { get; set; }
        DbSet<CommentEntity> Comments { get; set; }
        DbSet<GameEntity> Games { get; set; }
        DbSet<InfoEntity> Info { get; set; }
        DbSet<PostEntity> Posts { get; set; }
        DbSet<PublisherEntity> Publishers { get; set; }
        DbSet<ReviewEntity> Reviews { get; set; }
        DbSet<SupportEntity> Support { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
