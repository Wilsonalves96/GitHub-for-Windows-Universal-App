using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using AppStudio.Uwp.Navigation;
using Spotted.Services;
using Spotted.ViewModels;
using Spotted.Views;

namespace Spotted
{
    public sealed partial class Shell : Page
    {
	    private bool isFullScreen = false;

        public Shell() : base()
        {
            this.ViewModel = new ShellViewModel();

            this.InitializeComponent();

            var applicationView = ApplicationView.GetForCurrentView();

            this.Loaded += MainPage_Loaded;
            FullScreenService.FullScreenModeChanged += ((sender, e) => { isFullScreen = e; });
        }
        
        public ShellViewModel ViewModel { get; set; }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Initialize(typeof(App), MainFrame);
            NavigationService.NavigateToPage(typeof(HomePage));
        }

		private void PageLayout_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (FullScreenService.CurrentPageSupportFullScreen)
            {
                if (e.Key == Windows.System.VirtualKey.F5)
                {
                    FullScreenService.EnterFullScreenMode(true);
                }
                else if (e.Key == Windows.System.VirtualKey.Escape)
                {
                    if (isFullScreen)
                    {
                        FullScreenService.ExitFullScreenMode();
                    }
                    else
                    {
                        TryGoBack();
                    }
                }
            }
			else
            {
                if (e.Key == Windows.System.VirtualKey.Escape)
                {
                    TryGoBack();
                }
            }
        }

        private void TryGoBack()
        {
            if (NavigationService.CanGoBack())
            {
                NavigationService.GoBack();
            }
        }
    }
}
