using Prism.VisualStudio.Wizards.Xamarin.Models;
using System.Windows;

namespace Prism.VisualStudio.Wizards.Xamarin.UI
{
    /// <summary>
    /// Interaction logic for NewProjectDialog.xaml
    /// </summary>
    public partial class NewProjectDialog : Window
    {
        public ProjectDialogResult Result { get; set; }

        public NewProjectDialog()
        {
            InitializeComponent();
            var vm = new NewProjectDialogViewModel();
            vm.ProjectCreated += ProjectCreated;
            DataContext = vm;

            Closing += NewProjectDialog_Closing;
        }

        void ProjectCreated(object sender,ProjectDialogResultEventArgs e)
        {
            Result = e.Result;
            DialogResult = true;
        }

        private void NewProjectDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
