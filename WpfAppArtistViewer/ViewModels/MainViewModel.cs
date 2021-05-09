using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfAppArtistViewer;
using WpfAppArtistViewer.Message;
using WpfAppArtistViewer.Models;

namespace WpfAppArtistViewer.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public MainViewModel(IMessenger messenger)
        {
            messenger.Register<NavigationMessage>(this, message =>
            {
                var viewModel = App.Services.GetInstance(message.ViewModelType) as ViewModelBase;
                CurrentViewModel = viewModel;
            });
        }
    }
}