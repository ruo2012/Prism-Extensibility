using Prism.Modularity;
using Module.XF.Views;
using Module.XF.ViewModels;
#if (AutofacContainer)
using Autofac;
using Prism.Autofac;
#endif
#if (DryIocContainer)
using DryIoc;
using Prism.DryIoc;
#endif
#if (NinjectContainer)
using Ninject;
using Prism.Ninject;
#endif
#if (UnityContainer)
using Microsoft.Practices.Unity;
using Prism.Unity;
#endif

namespace Module.XF
{
    public class ModuleName : IModule
    {
#if (AutofacContainer)
        public void Initialize() { }

        public static void Initialize(ContainerBuilder builder)
        {
            builder.Register<IFooService, FooService>();

            builder.RegisterTypeForNavigation<ViewA, ViewAViewModel>();
        }
#elseif (DryIocContainer)
        private IContainer _container { get; }

        public ModuleName(IContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA, ViewAViewModel>();
        }
#elseif (NinjectContainer)
        private IKernel _kernel { get; }

        public ModuleName(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Initialize()
        {
            _kernel.RegisterTypeForNavigation<ViewA, ViewAViewModel>();
        }
#elseif (UnityContainer)
        private IUnityContainer _container { get; }

        public ModuleName(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA, ViewAViewModel>();
        }
#endif
    }
}
