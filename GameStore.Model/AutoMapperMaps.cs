
using GameStore.DAL.Models;
using GameStore.Model.Common;
namespace GameStore.Model
{
    public static class AutoMapperMaps
    {
        public static void Initalize()
        {
            AutoMapper.Mapper.CreateMap<ICart, CartEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<CartEntity, Cart>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IComment, CommentEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<CommentEntity, Comment>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IPublisher, PublisherEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<PublisherEntity, Publisher>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IGame, GameEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<GameEntity, Game>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IInfo, InfoEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InfoEntity, Info>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IPost, PostEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<PostEntity, Post>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IReview, ReviewEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ReviewEntity, Review>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ISupport, SupportEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<SupportEntity, Support>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IUser, UserEntity>().ReverseMap();
            AutoMapper.Mapper.CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
