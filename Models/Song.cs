using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollectionManager.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        public string? Title { get; set; }
        
        [ForeignKey("RecordingArtist")]
        public int ArtistID { get; set; }

        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        public string? Genre { get; set; }

        public double BPM { get; set; }
        public int Duration { get; set; }
        public int? NumOfListens { get; set; }

        public string Vocals { get; set; }

        public DateTime? DateAdded { get; set; }
        public Int64 Favorite { get; set; }


    }
}
