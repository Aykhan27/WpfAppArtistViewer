using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfAppArtistViewer.Message;
using WpfAppArtistViewer.Models;
using WpfAppArtistViewer.Services;

namespace WpfAppArtistViewer.ViewModels
{
    class InfoPageViewModel : ViewModelBase
    {
        private readonly IArtistsApiClient _artistsApiClient;
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;
        public InfoPageViewModel(IArtistsApiClient artistsApiClient, INavigationService navigationService, IMessenger messenger)
        {
            _artistsApiClient = artistsApiClient;
            _navigationService = navigationService;
            _messenger = messenger;

            _messenger?.Register<ArtistDetailsMessage>(this, message =>
            {
                ArtistName = message.Artist.name;
                Bio = message.Artist.bio.summary;
                FirstPublished = message.Artist.bio.published;
                Listeners = message.Artist.stats.listeners;
                ImgageSource = message.Artist.image[4].text;
                ObservableCollection<Artist> simularArtistsTemp = new ObservableCollection<Artist>();
                for (int i = 0; i < 4; i++)
                    simularArtistsTemp.Add(message.Artist.similar.artist[i]);
                SimilarArtist = simularArtistsTemp;
            });
        }

        private ObservableCollection<Artist> _similarArtist;
        public ObservableCollection<Artist> SimilarArtist
        {
            get => _similarArtist;
            set => Set(ref _similarArtist, value);
        }

        private string _artistName;
        public string ArtistName
        {
            get => _artistName;
            set => Set(ref _artistName, value);
        }

        private string _listeners;
        public string Listeners
        {
            get => _listeners;
            set => Set(ref _listeners, value);
        }

        private string _firstPublished;
        public string FirstPublished
        {
            get => _firstPublished;
            set => Set(ref _firstPublished, value);
        }

        private string _bio;
        public string Bio
        {
            get => _bio;
            set
            {
                value = value.Trim('\n');
                var index = value.IndexOf("<a");
                value = value.Remove(index, value.LastIndexOf("a>") - index + 2);
                Set(ref _bio, value);
            }
        }

        private string _imgageSource;
        public string ImgageSource
        {
            get => _imgageSource;
            set => Set(ref _imgageSource, value);
        }

        private void GetActor(object name)
        {
            Thread.Sleep(200);
            _navigationService.NavigateTo<InfoPageViewModel>();
            _messenger.Send(new ArtistDetailsMessage { Artist = _artistsApiClient.GetArtistByArtistName(name as string) });
        }

        private RelayCommand<Artist> _readMoreCommand;
        public RelayCommand<Artist> ReadMoreCommand => _readMoreCommand ??= new RelayCommand<Artist>(
            param =>
            {
                if (param != null)
                {
                    new Thread(new ParameterizedThreadStart(GetActor)).Start(param.name);
                }
            }
        );
    }
}