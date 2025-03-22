namespace MusicCollectionManager.ViewModels
{
    public class SongViewModel
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StageName { get; set; }
        public string BandName { get; set; }
        public string AlbumName { get; set; }
        public int? Year { get; set; }
        public string Genre { get; set; }
        public double? BPM { get; set; }
        public int? Duration { get; set; }
        public int? NumOfListens { get; set; }
        public string Vocals { get; set; }
        public DateTime? DateAdded { get; set; }
        public Int64 Favorite { get; set; }

    }
}
