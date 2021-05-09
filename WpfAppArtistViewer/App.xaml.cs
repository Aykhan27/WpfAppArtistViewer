using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfAppArtistViewer.ViewModels;
using SimpleInjector;
using WpfAppArtistViewer.Models;
using WpfAppArtistViewer.Services;

namespace WpfAppArtistViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Services;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            RegisterServices();
            Start<HomePageViewModel>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //MessageBox.Show("Bye!");
            base.OnExit(e);
        }

        private void RegisterServices()
        {
            Services = new Container();

            Services.RegisterSingleton<IMessenger, Messenger>();
            Services.RegisterSingleton<INavigationService, NavigationService>();
            Services.RegisterSingleton<IArtistsApiClient,ArtistsApiClient>();
            Services.RegisterSingleton<HomePageViewModel>();
            Services.RegisterSingleton<InfoPageViewModel>();

            Services.Verify();
        }

        private void Start<T>() where T : ViewModelBase
        {
            var windowViewModel = Services.GetInstance<MainViewModel>();
            windowViewModel.CurrentViewModel = Services.GetInstance<T>();
            var window = new MainWindow { DataContext = windowViewModel };
            window.ShowDialog();
        }
    }
}
