using GameStore.Common;
using GameStore.DAL.Mapping;
using GameStore.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GameStore.DAL
{
    /// <summary>
    /// Games Store context for communication with database
    /// </summary>
    public class GamesStoreContext : IdentityDbContext<UserEntity>, IGamesStoreContext
    {
        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        public GamesStoreContext() : base(ConnectionStrings.TEST_DB_CONNECTION, throwIfV1Schema: false) 
        {
            base.RequireUniqueEmail = true;
        }

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="connection">Database name or connection string</param>
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
        public DbSet<TopicEntity> Topics { get; set; }
       
        #endregion

        #region Methods

        /// <summary>
        /// Database configuration options and mappings
        /// </summary>
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
            modelBuilder.Configurations.Add(new TopicMap());

            modelBuilder.Conventions.Add<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        // Summary:
        //     A DbSet represents the collection of all entities in the context, or that
        //     can be queried from the database, of a given type. DbSet objects are created
        //     from a DbContext using the DbContext.Set method.
        //
        // Type parameters:
        //   TEntity:
        //     The type that defines the set.
        //
        // Remarks:
        //     Note that DbSet does not support MEST (Multiple Entity Sets per Type) meaning
        //     that there is always a one-to-one correlation between a type and a set
        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();                   
        }
 
        #endregion
    }
}
