namespace Prism.VisualStudio.Wizards.Xamarin.Models
{
    public class ProjectDialogResult
    {
        public bool CreateAndroid { get; set; } = true;

        public bool CreateiOS { get; set; } = true;

        public bool CreateUwp { get; set; }

        public bool Cancelled { get; set; }

        public ContainerType ContainerType { get; set; }

        public ProjectDialogResult(bool cancelled = true)
        {
            Cancelled = cancelled;
        }

        public ProjectDialogResult(bool createAndroid, bool createiOS, bool createUwp, ContainerType containerType)
        {
            CreateAndroid = createAndroid;
            CreateiOS = createiOS;
            CreateUwp = createUwp;
            ContainerType = containerType;
            Cancelled = false;
        }
    }
}
