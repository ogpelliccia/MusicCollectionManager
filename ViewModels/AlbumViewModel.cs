using MusicCollectionManager.Models;

namespace MusicCollectionManager.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumID { get; set; }
        public string? AlbumName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StageName { get; set; }
        public string? BandName { get; set; }
        public int GroupID { get; set; }
        public string? RecordLabel { get; set; }
        public int? Year { get; set; }
        public int? NumOfSongs { get; set; }
        public int? TotalDuration { get; set; }


    }
}
