
using GameStore.Model.Common;
namespace GameStore.Model
{ 
    public class DIModule :Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICart>().To<Cart>();
            Bind<IComment>().To<Comment>();
            Bind<IPublisher>().To<Publisher>();
            Bind<IGame>().To<Game>();
            Bind<IGameImage>().To<GameImage>();
            Bind<IInfo>().To<Info>();
            Bind<IPost>().To<Post>();
            Bind<IReview>().To<Review>();
            Bind<ISupport>().To<Support>();
            Bind<IUser>().To<User>();
           
        }
    }
}
