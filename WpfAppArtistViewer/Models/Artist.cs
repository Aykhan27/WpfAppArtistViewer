using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppArtistViewer.Models
{

    public class Result
    {
        public Results results { get; set; }
    }

    public class Results
    {
        public Artistmatches artistmatches { get; set; }
    }


    public class Artistmatches
    {
        public Artist[] artist { get; set; }
    }

    public class Artistmatch
    {
        public Artist artist { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }
        public string listeners { get; set; }
        public string mbid { get; set; }
        public string url { get; set; }
        public myImage[] image { get; set; }
        public Similar similar { get; set; }
        public Stats stats { get; set; }
        public Bio bio { get; set; }
    }
    public class Stats
    {
        public string listeners { get; set; }
        public string playcount { get; set; }
    }
    public class Similar
    {
        public Artist[] artist { get; set; }
    }

    public class Bio
    {
        public string published { get; set; }
        public string summary { get; set; }
    }

    public class myImage
    {
        public string text { get; set; }
        public string size { get; set; }
    }
}
