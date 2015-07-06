using GameStore.Common;
using GameStore.DAL.Mapping;
using GameStore.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GameStore.DAL
{
    public class GamesStoreContext : IdentityDbContext<UserEntity>, IGamesStoreContext
    {
        #region Constructors

        public GamesStoreContext() : base(ConnectionStrings.TEST_DB_CONNECTION, throwIfV1Schema: false) 
        {
            base.RequireUniqueEmail = true;
        }
        public GamesStoreContext(string connection) : base(connection, throwIfV1Schema: false)
        {
            base.RequireUniqueEmail = true;
        }
      
        #endregion

        #region Proporties

        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GameImageEntity> GameImages { get; set; }
        public DbSet<InfoEntity> Info { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<SupportEntity> Support { get; set; }
       
        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CartMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new PublisherMap());
            modelBuilder.Configurations.Add(new GameMap());
            modelBuilder.Configurations.Add(new GameImageMap());
            modelBuilder.Configurations.Add(new InfoMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new ReviewMap());
            modelBuilder.Configurations.Add(new SupportMap());
            modelBuilder.Configurations.Add(new UserMap());

         

            base.OnModelCreating(modelBuilder);
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();                   
        }
 
        #endregion
    }
}
