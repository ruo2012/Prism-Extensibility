using Prism.Ioc;
using Prism.Modularity;
using Module.XF.Views;
using Module.XF.ViewModels;

namespace Module.XF
{
    public class ModuleName : IModule
    {
        public void Initialize() { /* deprecated */ }

        public void OnInitialized()
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
