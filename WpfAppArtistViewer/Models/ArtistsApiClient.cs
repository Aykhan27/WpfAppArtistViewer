using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace WpfAppArtistViewer.Models
{
    class ArtistsApiClient : IArtistsApiClient
    {
        private readonly WebClient _webClient;

        private readonly string _appKey = "5096a14347e132698bf37de29645a31c";
        private readonly string _apiUrl = "http://ws.audioscrobbler.com/2.0/?";

        public ArtistsApiClient()
        {
            _webClient = new WebClient();
        }

        public ObservableCollection<Artist> GetArtistsByArtistName(string artistName)
        {
            var json = _webClient.DownloadString($"{_apiUrl}method=artist.search&artist={artistName}&api_key={_appKey}&format=json");
            var artist = JsonSerializer.Deserialize<Result>(json);
            return new ObservableCollection<Artist>(artist.results.artistmatches.artist.ToList());
        }

        public Artist GetArtistByArtistName(string ArtistName)
        {
            var json = _webClient.DownloadString($"{_apiUrl}method=artist.getinfo&artist={ArtistName}&api_key={_appKey}&format=json");
            var artist = JsonSerializer.Deserialize<Artistmatch>(json);
            return artist.artist;
        }

        public Artist GetArtistByArtistMBID(string ArtistMBid)
        {
            var json = _webClient.DownloadString($"{_apiUrl}method=artist.getinfo&mbid={ArtistMBid}&api_key={_appKey}&format=json");
            var artist = JsonSerializer.Deserialize<Artistmatch>(json);
            return artist.artist;
        }
    }
}
