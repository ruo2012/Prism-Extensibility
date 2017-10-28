using BlankApp.Views;
using System.Windows;
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

namespace BlankApp
{
    #if (AutofacContainer)
    class Bootstrapper : AutofacBootstrapper
    #endif
    #if (DryIocContainer)
    class Bootstrapper : DryIocBootstrapper
    #endif
    #if (NinjectContainer)
    class Bootstrapper : NinjectBootstrapper
    #endif
    #if (UnityContainer)
    class Bootstrapper : UnityBootstrapper
    #endif
    {
        protected override DependencyObject CreateShell()
        {
#if (NinjectContainer)
            return Kernel.TryGet<MainWindow>();
#else
            return Container.Resolve<MainWindow>();
#endif
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
