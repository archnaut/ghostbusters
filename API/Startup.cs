using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using API.Domain;
using API.Infrastructure;
using JetBrains.Annotations;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(API.Startup))]

namespace API
{
    public class Startup
    {
        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();

            configuration.MapHttpAttributeRoutes();

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(configuration);

            app.UseWebApi(configuration);
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel(); 
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<DbContext>().To<DataContext>();
            kernel.Bind<IRepository>().To<Repository>();

            return kernel;
        }
    }
}
