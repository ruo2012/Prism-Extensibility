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
                //Note: we must include the 'v' in the version number, or the wizard will remove all dots from the version when pased to the template
                //causing a break for non-english versions of Visual Studio
                replacementsDictionary.Add("passthrough:TargetFrameworkVersion", $"v{replacementsDictionary["$targetframeworkversion$"]}");
            }
            catch
            {
                string destinationDirectory = replacementsDictionary["$destinationdirectory$"];
                string solutionDirectory = replacementsDictionary["$solutiondirectory$"];

                try
                {
                    if (Directory.Exists(destinationDirectory))
                        Directory.Delete(destinationDirectory);
                }
                catch { /* If it fails (doesn't exist/contains files/read-only), let the directory stay. */ }

                try
                {
                    if (Directory.Exists(solutionDirectory))
                        Directory.Delete(solutionDirectory);
                }
                catch { /* If it fails (doesn't exist/contains files/read-only), let the directory stay. */ }

                throw;
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
