using System.ComponentModel.DataAnnotations;

namespace MusicCollectionManager.Models
{
    public class Musician
    {
        [Key]
        public int MusicianID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string? Country { get; set; }
        public string? Hometown { get; set; }
        public string Gender { get; set; }
        public string? Ethnicity { get; set; }
        public string? PrimaryOccupation { get; set; }

    }
}
