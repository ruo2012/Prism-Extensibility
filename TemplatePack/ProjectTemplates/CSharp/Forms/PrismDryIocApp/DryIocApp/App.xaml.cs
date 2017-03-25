using DryIoc;
using Prism.DryIoc;
using $safeprojectname$.ViewModels;
using $safeprojectname$.Views;
using Xamarin.Forms;

namespace $safeprojectname$
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
			Container.RegisterTypeForNavigation<MainPage>();
			Container.Register<MainPageViewModel>(); //DryIoc requires you to register concrete types. This will be improved in a future Prism update
		}
    }
}
