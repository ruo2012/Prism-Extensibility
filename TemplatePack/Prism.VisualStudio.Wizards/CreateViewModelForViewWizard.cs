using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using EnvDTE;
using System.IO;

namespace Prism.VisualStudio.Wizards
{
    public class CreateViewModelForViewWizard : IWizard
    {
        EnvDTE.DTE _dte = null;
        string _viewName;
        string _viewModelName;
        string _templatesDirectory;
        string _rootNamespace;
        string _platform;

        readonly string ViewFolderName = "Views";
        readonly string ViewModelFolderName = "ViewModels";

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
            if (!_rootNamespace.Contains(ViewFolderName))
                return;

            var templateSubDirectoryReplaceKey = _platform.Equals("xf") ? "Xamarin.Forms" : "WPF";
            string templatePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(_templatesDirectory.Replace(templateSubDirectoryReplaceKey, "Code")), "PrismViewModel.zip\\PrismViewModel.vstemplate");

            Array activeProjects = (Array)_dte.ActiveSolutionProjects;
            Project activeProject = (Project)activeProjects.GetValue(0);

            foreach(ProjectItem item in activeProject.ProjectItems)
            {
                if (item.Name == ViewModelFolderName && item.Kind == Constants.vsProjectItemKindPhysicalFolder)
                {
                    item.ProjectItems.AddFromTemplate(templatePath, $"{_viewModelName}.cs");
                }

                if (_platform.Equals("xf"))
                {
                    if (item.Name == "App.xaml")
                    {
                        ProjectItem appXamlCS = item.ProjectItems.Item(1);
                        EditAppRegisterTypesForNavigation(appXamlCS.FileCodeModel.CodeElements);
                    }

                    if (item.Name == "App.cs")
                    {
                        EditAppRegisterTypesForNavigation(item.FileCodeModel.CodeElements);
                    }
                }                    
            }
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _dte = automationObject as EnvDTE.DTE;
            _platform = replacementsDictionary["$platform$"];
            _rootNamespace = replacementsDictionary["$rootnamespace$"];
            _viewName = replacementsDictionary["$safeitemname$"];
            _viewModelName = $"{_viewName}ViewModel";
            _templatesDirectory = Path.GetDirectoryName(customParams[0] as string);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        void EditAppRegisterTypesForNavigation(CodeElements codeElements)
        {
            CodeFunction registerTypesFunction = GetRegisterTypesMethod(codeElements);
            if (registerTypesFunction != null)
            {
                TextPoint methodEndPoint = registerTypesFunction.GetEndPoint(vsCMPart.vsCMPartBody);
                EditPoint editPoint = methodEndPoint.CreateEditPoint();
                editPoint.Insert($"Container.RegisterTypeForNavigation<{_viewName}>();");
                editPoint.SmartFormat(methodEndPoint);
            }
        }

        CodeFunction GetRegisterTypesMethod(CodeElements codeElements)
        {
            foreach (CodeElement codeElement in codeElements)
            {
                if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
                {
                    CodeNamespace codeNamespace = (CodeNamespace)codeElement;
                    CodeClass codeClass = (CodeClass)codeNamespace.Children.Item("App");
                    return (CodeFunction)codeClass.Members.Item("RegisterTypes");
                }
            }

            return null;
        }
    }
}
