namespace MusicCollectionManager.ViewModels
{
    public class CreditViewModel
    {
        public int CreditID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditType { get; set; }
        public string AlbumName { get; set; }
        public int ArtistID { get; set; }
        public string ArtistFirstName {  get; set; }
        public string ArtistLastName { get; set; }
        public string ArtistStageName { get; set; }
        public string? BandName { get; set; }
        public int? Year { get; set; }
        public int? NumOfSongs { get; set; }

    }
}
