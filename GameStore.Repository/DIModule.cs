using GameStore.DAL;
using GameStore.DAL.Models;
using GameStore.Repository.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Extensions.Factory;
using Ninject;
using Ninject.Parameters;

namespace GameStore.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        /// <summary>
        /// Loads module
        /// </summary>
        public override void Load()
        {
            #region Bindings

            // Context, generic repo, unit of work
            Bind<IGamesStoreContext>().To<GamesStoreContext>();
            Bind<IRepository>().To<Repository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();

            // Bind user store and manager
            //Bind<IUserStore<UserEntity>>().To<UserStore<UserEntity>>().WithConstructorArgument(new GamesStoreContext());            
            //Bind<UserManager<UserEntity>>().ToSelf();

            Bind<UserManager<UserEntity>>().ToSelf().WithConstructorArgument(typeof(IUserStore<UserEntity>), new UserStore<UserEntity>(new GamesStoreContext()));
            Bind<IUserManagerFactory>().ToFactory();
;

            // Other repos
            Bind<ICartRepository>().To<CartRepository>();
            Bind<ICommentRepository>().To<CommentRepository>();
            Bind<IPublisherRepository>().To<PublisherRepository>();
            Bind<IGameRepository>().To<GameRepository>();
            Bind<IGameImageRepository>().To<GameImageRepository>();
            Bind<IInfoRepository>().To<InfoRepository>();
            Bind<IPostRepository>().To<PostRepository>();
            Bind<IReviewRepository>().To<ReviewRepository>();
            Bind<ISupportRepository>().To<SupportRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IUserRepository>().To<UserRepository>();


            #endregion

        }
    }
}
