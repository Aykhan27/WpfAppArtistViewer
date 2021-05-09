using GalaSoft.MvvmLight;

namespace WpfAppArtistViewer.Services
{
    interface INavigationService
    {
        void NavigateTo<T>() where T : ViewModelBase;
    }
}