using WoodworkingWorkshop.Forms;
using Unity;
using Unity.Lifetime;
using WoodworkingWorkshop.Forms;
using WoodworkingWorkshop.Repositories;
using WoodworkingWorkshop.Repositories.Implementations;

namespace WoodworkingWorkshop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(CreateContainer().Resolve<FormMain>());
        }

        private static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new TransientLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new TransientLifetimeManager());
            container.RegisterType<IMaterialRepository, MaterialRepository>(new TransientLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new TransientLifetimeManager());
            container.RegisterType<IMaterialUsageRepository, MaterialUsageRepository>(new TransientLifetimeManager());
            return container;
        }
    }
}