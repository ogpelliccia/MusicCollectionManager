using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollectionManager.Models
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }

        [ForeignKey("RecordingArtist")]
        public int? ArtistID { get; set; }

        [ForeignKey("Group")]
        public int? GroupID { get; set; }
        public string? RecordLabel { get; set; }
        public int? Year { get; set; }
        public int? NumOfSongs { get; set; }
        public int? TotalDuration { get; set; }

    }
}
