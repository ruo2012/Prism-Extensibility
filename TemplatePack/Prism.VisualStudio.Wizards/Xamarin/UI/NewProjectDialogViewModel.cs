using Prism.VisualStudio.Wizards.Core;
using Prism.VisualStudio.Wizards.Models;

namespace Prism.VisualStudio.Wizards.Xamarin.UI
{
    internal class NewProjectDialogViewModel : ViewModelBase
    {
        private bool _createAndroid;
        public bool CreateAndroid
        {
            get { return _createAndroid; }
            set { SetProperty(ref _createAndroid, value); }
        }

        private bool _createiOS;
        public bool CreateiOS
        {
            get { return _createiOS; }
            set { SetProperty(ref _createiOS, value); }
        }

        private bool _createUwp;
        public bool CreateUwp
        {
            get { return _createUwp; }
            set { SetProperty(ref _createUwp, value); }
        }

        public NewProjectDialogViewModel() : base()
        {
            CreateAndroid = RegistryHelper.GetValue(nameof(CreateAndroid), true);
            CreateiOS = RegistryHelper.GetValue(nameof(CreateiOS), true);
            CreateUwp = RegistryHelper.GetValue(nameof(CreateUwp), true);
        }

        protected override void CreateProject()
        {
            base.CreateProject();

            RegistryHelper.WriteValue(nameof(CreateAndroid), CreateAndroid);
            RegistryHelper.WriteValue(nameof(CreateiOS), CreateiOS);
            RegistryHelper.WriteValue(nameof(CreateUwp), CreateUwp);

            var result = new ProjectDialogResult(CreateAndroid, CreateiOS, CreateUwp, SelectedContainer);
            RaiseCreateProject(new ProjectDialogResultEventArgs(result));
        }

        protected override bool CanCreateProject()
        {
            return CreateAndroid || CreateiOS || CreateUwp;
        }
    }
}
