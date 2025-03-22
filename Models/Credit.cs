using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollectionManager.Models
{
    public class Credit
    {
        [Required]
        public int CreditID { get; set; }

        [ForeignKey("Musician")]
        public int MusicianID { get; set; }
        public string CreditType { get; set; }

        [ForeignKey("Album")]
        public int AlbumID { get; set; }

    }
}
