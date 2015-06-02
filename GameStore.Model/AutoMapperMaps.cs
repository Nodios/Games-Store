
using GameStore.DAL.Models;
using GameStore.Model.Common;
namespace GameStore.Model
{
    public static class AutoMapperMaps
    {
        public static void Initalize()
        {
            AutoMapper.Mapper.CreateMap<CartEntity, ICart>().ReverseMap();
            AutoMapper.Mapper.CreateMap<CartEntity, ICart>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IComment, Comment>().ReverseMap();
            AutoMapper.Mapper.CreateMap<CommentEntity, IComment>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ICompany, Company>().ReverseMap();
            AutoMapper.Mapper.CreateMap<CompanyEntity, ICompany>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IGame, Game>().ReverseMap();
            AutoMapper.Mapper.CreateMap<GameEntity, IGame>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IInfo, Info>().ReverseMap();
            AutoMapper.Mapper.CreateMap<InfoEntity, IInfo>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IPost, Post>().ReverseMap();
            AutoMapper.Mapper.CreateMap<PostEntity, IPost>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IReview, Review>().ReverseMap();
            AutoMapper.Mapper.CreateMap<ReviewEntity, IReview>().ReverseMap();

            AutoMapper.Mapper.CreateMap<ISupport, Support>().ReverseMap();
            AutoMapper.Mapper.CreateMap<SupportEntity, ISupport>().ReverseMap();

            AutoMapper.Mapper.CreateMap<IUser, User>().ReverseMap();
            AutoMapper.Mapper.CreateMap<UserEntity, IUser>().ReverseMap(); 
        }
    }
}
