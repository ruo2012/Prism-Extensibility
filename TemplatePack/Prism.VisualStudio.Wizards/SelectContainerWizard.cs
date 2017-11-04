using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using EnvDTE;
using Prism.VisualStudio.Wizards.UI;
using System.IO;

namespace Prism.VisualStudio.Wizards
{
    public class SelectContainerWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem) { }

        public void ProjectFinishedGenerating(Project project) { }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }

        public void RunFinished() { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                var dialog = new SelectContainerDialog();
                dialog.ShowDialog();
                var dialogResult = dialog.Result;

                if (dialogResult.Cancelled)
                    throw new WizardBackoutException();

                replacementsDictionary.Add("passthrough:Container", dialogResult.ContainerType.ToString());
                replacementsDictionary.Add("passthrough:TargetFrameworkVersion", replacementsDictionary["$targetframeworkversion$"]);
            }
            catch
            {
                var solutionDir = System.IO.Path.GetDirectoryName(replacementsDictionary["$destinationdirectory$"]);

                if (Directory.Exists(solutionDir))
                    Directory.Delete(solutionDir, true);

                throw;
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
