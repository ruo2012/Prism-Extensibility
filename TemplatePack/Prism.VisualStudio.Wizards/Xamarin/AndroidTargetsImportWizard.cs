using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using Microsoft.Build.Construction;

namespace Prism.VisualStudio.Wizards.Xamarin
{
    public class AndroidTargetsImportWizard : IWizard
    {
        private EnvDTE.DTE _dte = null;

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
            var androidProject = GetAndroidProject();
            if (androidProject == null)
                return;

            var projectPath = androidProject.FullName;
            ProjectRootElement projectRoot = ProjectRootElement.Open(projectPath);
            projectRoot.AddImport(@"$(MSBuildExtensionsPath)\Xamarin\Android\Xamarin.Android.CSharp.targets");
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _dte = automationObject as EnvDTE.DTE;
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        Project GetAndroidProject()
        {
            foreach (Project project in _dte.Solution.Projects)
            {
                if (project.Name.Contains(".Android"))
                    return project;
            }

            return null;
        }
    }
}
