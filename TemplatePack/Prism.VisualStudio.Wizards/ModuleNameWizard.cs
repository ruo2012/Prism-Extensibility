using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Linq;
using System.Collections.Generic;
using EnvDTE;

namespace Prism.VisualStudio.Wizards
{
    public class ModuleNameWizard : IWizard
    {
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            
        }

        public void ProjectFinishedGenerating(Project project)
        {
            
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            
        }

        public void RunFinished()
        {
            
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var projectName = replacementsDictionary["$projectname$"];
            var moduleName = String.Format("{0}{1}", projectName.Split('.').Last(), "Module");
            replacementsDictionary.Add("passthrough:ModuleName", moduleName);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
