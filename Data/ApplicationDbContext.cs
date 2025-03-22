using Microsoft.EntityFrameworkCore;
using MusicCollectionManager.Models;

namespace MusicCollectionManager.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<RecordingArtist> RecordingArtists { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<GroupLinking> GroupLinkings { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Credit> Credits { get; set; }
    }
}
