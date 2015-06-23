[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GameStore.WebApi.App_Start.NinjectWeb), "Start")]

namespace GameStore.WebApi.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject.Web.Common;

    public static class NinjectWeb
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}