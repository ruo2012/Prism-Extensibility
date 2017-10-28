using Prism.VisualStudio.Wizards.Models;
using System;
using System.Windows.Input;

namespace Prism.VisualStudio.Wizards.Core
{
    internal class ViewModelBase : BindableBase
    {
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

        public ViewModelBase()
        {
            Containers = Enum.GetValues(typeof(ContainerType));
            SelectedContainer = RegistryHelper.GetValue(nameof(SelectedContainer), ContainerType.DryIoc);
        }

        protected virtual void CreateProject()
        {
            RegistryHelper.WriteValue(nameof(SelectedContainer), SelectedContainer);
        }

        protected virtual bool CanCreateProject()
        {
            return true;
        }

        protected void RaiseCreateProject(ProjectDialogResultEventArgs e)
        {
            OnProjectCreated(e);
        }

        protected virtual void OnProjectCreated(ProjectDialogResultEventArgs e)
        {
            ProjectCreated?.Invoke(this, e);
        }
    }
}
