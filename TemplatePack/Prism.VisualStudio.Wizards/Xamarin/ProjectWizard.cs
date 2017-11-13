using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using Prism.VisualStudio.Wizards.Xamarin.UI;
using System.Collections.Generic;
using System.IO;

namespace Prism.VisualStudio.Wizards.Xamarin
{
    public class ProjectWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem) { }

        public void ProjectFinishedGenerating(Project project) { }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem) { }

        public void RunFinished() { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                NewProjectDialog dialog = new NewProjectDialog();
                dialog.ShowDialog();
                var dialogResult = dialog.Result;

                if (dialogResult.Cancelled)
                    throw new WizardBackoutException();

                replacementsDictionary.Add("passthrough:CreateAndroidProject", dialogResult.CreateAndroid.ToString());
                replacementsDictionary.Add("passthrough:CreateiOSProject", dialogResult.CreateiOS.ToString());
                replacementsDictionary.Add("passthrough:CreateUWPProject", dialogResult.CreateUwp.ToString());
                replacementsDictionary.Add("passthrough:Container", dialogResult.ContainerType.ToString());
            }
            catch
            {
                string solutionDirectory = replacementsDictionary["$solutiondirectory$"];

                if (Directory.Exists(solutionDirectory))
                    Directory.Delete(solutionDirectory, true);

                throw;
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
