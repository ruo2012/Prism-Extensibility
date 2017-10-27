using System;

namespace Prism.VisualStudio.Wizards.Xamarin.Models
{
    public class ProjectDialogResultEventArgs : EventArgs
    {
        public ProjectDialogResult Result { get; }

        public ProjectDialogResultEventArgs(ProjectDialogResult result)
        {
            Result = result;
        }
    }
}
