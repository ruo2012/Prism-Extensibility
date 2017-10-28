using Prism.VisualStudio.Wizards.Models;
using System.Windows;

namespace Prism.VisualStudio.Wizards.UI
{
    /// <summary>
    /// Interaction logic for NewProjectDialog.xaml
    /// </summary>
    public partial class SelectContainerDialog : Window
    {
        public ProjectDialogResult Result { get; set; }

        public SelectContainerDialog()
        {
            InitializeComponent();
            var vm = new SelectContainerDialogViewModel();
            vm.ProjectCreated += ProjectCreated;
            DataContext = vm;

            Closing += SelectContainerDialog_Closing;
        }

        void ProjectCreated(object sender,ProjectDialogResultEventArgs e)
        {
            Result = e.Result;
            DialogResult = true;
        }

        private void SelectContainerDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Result == null)
                Result = new ProjectDialogResult();
        }

        private void _btnClose_Click(object sender, RoutedEventArgs e)
        {
            Result = new ProjectDialogResult();
            DialogResult = false;
        }
    }
}
