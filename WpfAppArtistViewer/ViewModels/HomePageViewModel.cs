using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfAppArtistViewer.Message;
using WpfAppArtistViewer.Models;
using WpfAppArtistViewer.Services;

namespace WpfAppArtistViewer.ViewModels
{
    class HomePageViewModel : ViewModelBase
    {
        private readonly IArtistsApiClient _artistsApiClient;
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        public HomePageViewModel(IArtistsApiClient artistsApiClient, INavigationService navigationService , IMessenger messenger)
        {
            _artistsApiClient = artistsApiClient;
            _navigationService = navigationService;
            _messenger = messenger;
            LoadingBarVisibility = Visibility.Hidden;
        }



        private ObservableCollection<Artist> _actors;
        public ObservableCollection<Artist> Actors
        {
            get => _actors;
            set => Set(ref _actors, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                Set(ref _searchText, value);
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        private Visibility _loadingBarVisibility;
        public Visibility LoadingBarVisibility
        {
            get => _loadingBarVisibility;
            set => Set(ref _loadingBarVisibility, value);
            
        }


        private void SetActor()
        {
            Actors = _artistsApiClient.GetArtistsByArtistName(SearchText);
            LoadingBarVisibility = Visibility.Hidden;
        }

        private void GetActor(object mbid)
        {
            Thread.Sleep(300);
            _navigationService.NavigateTo<InfoPageViewModel>();
            _messenger.Send(new ArtistDetailsMessage { Artist = _artistsApiClient.GetArtistByArtistMBID(mbid as string) });
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand => _searchCommand ??= new RelayCommand(
            () =>
            {
                Actors?.Clear();
                LoadingBarVisibility = Visibility.Visible;
                new Thread(new ThreadStart(SetActor)).Start();
            }
            , () => !string.IsNullOrEmpty(SearchText)
        );

        private RelayCommand<Artist> _artistViewCommand;
        public RelayCommand<Artist> ArtistViewCommand => _artistViewCommand ??= new RelayCommand<Artist>(
            param =>
            {
                if (param != null)
                {
                    new Thread(new ParameterizedThreadStart(GetActor)).Start(param.mbid);
                }
            }
        );

    }
}
