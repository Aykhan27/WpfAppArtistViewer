using System.Collections.ObjectModel;

namespace WpfAppArtistViewer.Models
{
    interface IArtistsApiClient
    {
        ObservableCollection<Artist> GetArtistsByArtistName(string ArtistName);
        Artist GetArtistByArtistName(string ArtistName);
        Artist GetArtistByArtistMBID(string ArtistMBid);
    }
}