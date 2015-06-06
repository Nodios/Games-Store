
using AutoMapper;
using GameStore.Model;
using GameStore.Model.Common;
namespace GameStore.WebApi.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Model.AutoMapperMaps.Initalize();

            // Company controller
            Mapper.CreateMap<IPublisher, WebApi.Controllers.PublisherController.PublisherModel>().ReverseMap();
            Mapper.CreateMap<Publisher, WebApi.Controllers.PublisherController.PublisherModel>().ReverseMap();
            Mapper.CreateMap<ISupport, WebApi.Controllers.PublisherController.SupportModel>().ReverseMap();
            Mapper.CreateMap<Support, WebApi.Controllers.PublisherController.SupportModel>().ReverseMap();

            // Game controller
            Mapper.CreateMap<IGame, WepApi.Controllers.GameController.GameModel>().ReverseMap();
            Mapper.CreateMap<Game, WepApi.Controllers.GameController.GameModel>().ReverseMap();
        }
    }
}