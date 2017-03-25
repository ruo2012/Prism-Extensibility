using Prism.Modularity;
using Prism.Regions;
using System;

namespace $safeprojectname$
{
    public class Module : IModule
    {
        IRegionManager _regionManager;

        public Module(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}