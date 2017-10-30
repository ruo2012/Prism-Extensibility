using Module.Wpf.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
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

namespace Module.Wpf
{
    public class ModuleName : IModule
    {
        private IRegionManager _regionManager;
#if (AutofacContainer)
        private ContainerBuilder _builder;

        public ModuleName(ContainerBuilder builder, IRegionManager regionManager)
        {
            _builder = builder;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _builder.RegisterTypeForNavigation<ViewA>();
        }
#elseif (DryIocContainer)
        private IContainer _container;

        public ModuleName(IContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA>();
        }
#elseif (NinjectContainer)
        private IKernel _kernel;

        public ModuleName(IKernel kernel, IRegionManager regionManager)
        {
            _kernel = kernel;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _kernel.RegisterTypeForNavigation<ViewA>();
        }
#elseif (UnityContainer)
        private IUnityContainer _container;

        public ModuleName(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA>();
        }
#endif
    }
}