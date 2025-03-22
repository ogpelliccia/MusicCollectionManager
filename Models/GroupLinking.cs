using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollectionManager.Models
{
    public class GroupLinking
    {
        [Key]
        public int LinkID { get; set; }

        [Required]
        [ForeignKey("ArtistID")]
        public int ArtistID { get; set; }

        [ForeignKey("GroupID")]
        public int GroupID { get; set; }

    }
}
