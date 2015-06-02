using GameStore.Common;
using GameStore.DAL.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace GameStore.DAL
{
    public class GamesStoreContext : DbContext, IGamesStoreContext
    {
        #region Constructors

        public GamesStoreContext() : base(ConnectionStrings.TEST_DB_CONNECTION) { }
        public GamesStoreContext(string connection) : base(connection) { }

        #endregion

        #region Proporties

        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CompanyEntity> Publishers { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<InfoEntity> Info { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<SupportEntity> Support { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CartMap());
            //modelBuilder.Configurations.Add(new CommentMap());
            //modelBuilder.Configurations.Add(new CompanyMap());
            //modelBuilder.Configurations.Add(new GameMap());
            //modelBuilder.Configurations.Add(new InfoMap());
            //modelBuilder.Configurations.Add(new PostMap());
            //modelBuilder.Configurations.Add(new ReviewMap());
            //modelBuilder.Configurations.Add(new SupportMap());
            //modelBuilder.Configurations.Add(new UserMap());

            // Reflection to find configurations
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach(var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
