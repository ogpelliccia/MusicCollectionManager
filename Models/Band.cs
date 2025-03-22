using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCollectionManager.Models
{
    public class Band
    {
        [Key]
        public int BandID { get; set; }

        [ForeignKey("Group")]
        public int GroupID { get; set; }
        public string BandName { get; set; }
        public int? YearFormed { get; set; }
        public int? YearDisbanded { get; set; }

    }
}
