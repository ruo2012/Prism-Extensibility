using Prism.VisualStudio.Wizards.Core;
using Prism.VisualStudio.Wizards.Xamarin.Models;
using System;
using System.Windows.Input;

namespace Prism.VisualStudio.Wizards.Xamarin.UI
{
    public class NewProjectDialogViewModel : BindableBase
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

        Array _containers;
        public Array Containers
        {
            get { return _containers; }
            set { SetProperty(ref _containers, value); }
        }

        private ContainerType _selectedContainer;

        public ContainerType SelectedContainer
        {
            get { return _selectedContainer; }
            set { _selectedContainer = value; }
        }

        ICommand _createProjectCommand;
        public ICommand CreateProjectCommand => 
            _createProjectCommand ?? (_createProjectCommand = new DelegateCommand(CreateProject, CanCreateProject));

        public EventHandler<ProjectDialogResultEventArgs> ProjectCreated;

        public NewProjectDialogViewModel()
        {
            Containers = Enum.GetValues(typeof(ContainerType));

            SelectedContainer = RegistryHelper.GetValue(nameof(SelectedContainer), ContainerType.DryIoc);
            CreateAndroid = RegistryHelper.GetValue(nameof(CreateAndroid), true);
            CreateiOS = RegistryHelper.GetValue(nameof(CreateiOS), true);
            CreateUwp = RegistryHelper.GetValue(nameof(CreateUwp), true);
        }

        private void CreateProject()
        {
            RegistryHelper.WriteValue(nameof(CreateAndroid), CreateAndroid);
            RegistryHelper.WriteValue(nameof(CreateiOS), CreateiOS);
            RegistryHelper.WriteValue(nameof(CreateUwp), CreateUwp);
            RegistryHelper.WriteValue(nameof(SelectedContainer), SelectedContainer);

            var result = new ProjectDialogResult(CreateAndroid, CreateiOS, CreateUwp, SelectedContainer);
            RaiseCreateProject(new ProjectDialogResultEventArgs(result));
        }

        private bool CanCreateProject()
        {
            return CreateAndroid || CreateiOS || CreateUwp;
        }

        void RaiseCreateProject(ProjectDialogResultEventArgs e)
        {
            OnProjectCreated(e);
        }

        protected virtual void OnProjectCreated(ProjectDialogResultEventArgs e)
        {
            ProjectCreated?.Invoke(this, e);
        }
    }
}
