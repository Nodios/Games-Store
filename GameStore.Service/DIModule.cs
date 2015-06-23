using GameStore.Service.Common;
using GameStore.Service;


namespace GameStore.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        /// <summary>
        /// Load modules into kernel
        /// </summary>
        public override void Load()
        {
            Bind<IPublisherService>().To<PublisherService>();
            Bind<IGamesService>().To<GamesService>();
            Bind<IPostService>().To<PostService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
