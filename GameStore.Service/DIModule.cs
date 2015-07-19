using GameStore.Service.Common;


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
            Bind<ICartService>().To<CartService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IGamesService>().To<GamesService>();
            Bind<IPostService>().To<PostService>();
            Bind<IReviewService>().To<ReviewService>();
            Bind<IUserService>().To<UserService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IGameImageService>().To<GameImageService>();
            Bind<ITopicService>().To<TopicService>();
            
        }
    }
}
