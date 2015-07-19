
using AutoMapper;
using GameStore.Model;
using GameStore.Model.Common;
using GameStore.WebApi.Models;


namespace GameStore.WebApi.App_Start
{
    public class AutoMapperWebApiLayerMapping : Profile
    {
        protected override void Configure()
        {
            // Cart 
            Mapper.CreateMap<ICart,CartModel>().ReverseMap();
            Mapper.CreateMap<Cart, CartModel>().ReverseMap();

            // Publisher and support 
            Mapper.CreateMap<IPublisher, PublisherModel>().ReverseMap();
            Mapper.CreateMap<Publisher, PublisherModel>().ReverseMap();
            Mapper.CreateMap<ISupport, SupportModel>().ReverseMap();
            Mapper.CreateMap<Support, SupportModel>().ReverseMap();

            // Comment 
            Mapper.CreateMap<IComment, CommentModel>().ReverseMap();
            Mapper.CreateMap<Comment, CommentModel>().ReverseMap();

            // Game 
            Mapper.CreateMap<IGame, GameModel>().ReverseMap();
            Mapper.CreateMap<Game, GameModel>().ReverseMap();

            // Game image 
            Mapper.CreateMap<IGameImage, GameImageModel>().ReverseMap();
            Mapper.CreateMap<GameImage, GameImageModel>().ReverseMap();

            // Post 
            Mapper.CreateMap<IPost, PostModel>().ReverseMap();
            Mapper.CreateMap<Post, PostModel>().ReverseMap();

            // Review 
            Mapper.CreateMap<IReview, ReviewModel>().ReverseMap();
            Mapper.CreateMap<Review,ReviewModel>().ReverseMap();

            // Order
            Mapper.CreateMap<IOrder, OrderModel>().ReverseMap();
            Mapper.CreateMap<Order, OrderModel>().ReverseMap();

            // Topic
            Mapper.CreateMap<ITopic, TopicModel>().ReverseMap();
            Mapper.CreateMap<Topic, TopicModel>().ReverseMap();

            // User 
            Mapper.CreateMap<IUser, UserModel>().ReverseMap();
            Mapper.CreateMap<User, UserModel>().ReverseMap();
        }

        public override string ProfileName
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}