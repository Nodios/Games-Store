
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
            // Cart controller
            Mapper.CreateMap<ICart,CartModel>().ReverseMap();
            Mapper.CreateMap<Cart, CartModel>().ReverseMap();

            // Company controller
            Mapper.CreateMap<IPublisher, PublisherModel>().ReverseMap();
            Mapper.CreateMap<Publisher, PublisherModel>().ReverseMap();
            Mapper.CreateMap<ISupport, SupportModel>().ReverseMap();
            Mapper.CreateMap<Support, SupportModel>().ReverseMap();

            // Game controller
            Mapper.CreateMap<IGame, GameModel>().ReverseMap();
            Mapper.CreateMap<Game, GameModel>().ReverseMap();

            // Game image controller
            Mapper.CreateMap<IGameImage, GameImageModel>().ReverseMap();
            Mapper.CreateMap<GameImage, GameImageModel>().ReverseMap();

            // Post controller
            Mapper.CreateMap<IPost, PostModel>().ReverseMap();
            Mapper.CreateMap<Post, PostModel>().ReverseMap();

            // Review controller
            Mapper.CreateMap<IReview, ReviewModel>().ReverseMap();
            Mapper.CreateMap<Review,ReviewModel>().ReverseMap();

            // Order
            Mapper.CreateMap<IOrder, OrderModel>().ReverseMap();
            Mapper.CreateMap<Order, OrderModel>().ReverseMap();

            // User controller
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