using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Hacathon.Controllers;
using Hacathon.Repositories;
using Hacathon.Services;

namespace Hacathon.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ProductsController>()
                .IsDefault()
                .LifestyleTransient());

            container.Register(Component.For<IProductRepository>()
                .ImplementedBy<ProductRepository>()
                .LifestyleSingleton());

            container.Register(Component.For<IProductService>()
                .ImplementedBy<ProductService>()
                .LifestyleSingleton());
        }
    }
}