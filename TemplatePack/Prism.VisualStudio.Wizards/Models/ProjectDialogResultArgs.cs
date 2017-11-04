using System;

namespace Prism.VisualStudio.Wizards.Models
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
