using AppStudio.Uwp;
using Windows.ApplicationModel;

namespace Spotted.ViewModels
{
    public class AboutThisAppViewModel : PageViewModel
    {
        public string Publisher
        {
            get
            {
                return "AppStudio";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Learn more about Windows App Studio.  Use this template to create an informationa" +
    "l app about a topic you care about.";
            }
        }
    }
}

