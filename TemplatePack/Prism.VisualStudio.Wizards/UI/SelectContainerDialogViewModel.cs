using Prism.VisualStudio.Wizards.Core;
using Prism.VisualStudio.Wizards.Models;

namespace Prism.VisualStudio.Wizards.UI
{
    internal class SelectContainerDialogViewModel : ViewModelBase
    {
        public SelectContainerDialogViewModel() : base()
        {

        }

        protected override void CreateProject()
        {
            base.CreateProject();

            var result = new ProjectDialogResult(false, false, false, SelectedContainer);
            RaiseCreateProject(new ProjectDialogResultEventArgs(result));
        }
    }
}