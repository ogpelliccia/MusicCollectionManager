using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollectionManager.Models
{
    public class RecordingArtist
    {
        [Key]
        public int ArtistID { get; set; }

        [ForeignKey("Musicians")]
        public int? MusicianID { get; set; }

        [ForeignKey("Group")]
        public int? GroupID { get; set; }
        public string? StageName { get; set; }

        [ForeignKey("Band")]
        public int? BandID { get; set; }

    }
}
