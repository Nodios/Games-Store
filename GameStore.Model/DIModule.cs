
using GameStore.Model.Common;
namespace GameStore.Model
{
    public class DIModule :Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ICart>().To<Cart>();
            Bind<IComment>().To<Comment>();
            Bind<ICompany>().To<Company>();
            Bind<IGame>().To<Game>();
            Bind<IInfo>().To<Info>();
            Bind<IPost>().To<Post>();
            Bind<IReview>().To<Review>();
            Bind<ISupport>().To<Support>();
            Bind<IUser>().To<User>();
        }
    }
}
