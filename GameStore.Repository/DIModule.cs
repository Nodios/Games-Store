using GameStore.DAL;
using GameStore.Repository.Common;

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

            // Other repos
            Bind<ICartRepository>().To<CartRepository>();
            Bind<ICommentRepository>().To<CommentRepository>();
            Bind<IPublisherRepository>().To<PublisherRepository>();
            Bind<IGameRepository>().To<GameRepository>();
            Bind<IInfoRepository>().To<InfoRepository>();
            Bind<IPostRepository>().To<PostRepository>();
            Bind<IReviewRepository>().To<ReviewRepository>();
            Bind<ISupportRepository>().To<SupportRepository>();
            Bind<IUserRepository>().To<UserRepository>();


            #endregion

        }
    }
}
