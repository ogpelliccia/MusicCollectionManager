using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicCollectionManager.Data;
using MusicCollectionManager.Models;
using MusicCollectionManager.ViewModels;

namespace MusicCollectionManager.Controllers
{
    public class SongsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var results = (from songs in _context.Songs
                           join albums in _context.Albums on songs.AlbumID equals albums.AlbumID into albumJoin
                           from album in albumJoin.DefaultIfEmpty()
                           join artists in _context.RecordingArtists on album.ArtistID equals artists.ArtistID into artistJoin
                           from artist in artistJoin.DefaultIfEmpty()
                           join musicians in _context.Musicians on artist.MusicianID equals musicians.MusicianID into musicianJoin
                           from musician in musicianJoin.DefaultIfEmpty()
                           join groups in _context.Groups on artist.GroupID equals groups.GroupID into groupJoin
                           from groupI in groupJoin.DefaultIfEmpty()
                           join bands in _context.Bands on artist.BandID equals bands.BandID into bandJoin
                           from band in bandJoin.DefaultIfEmpty()
                           select new SongViewModel()
                           {
                               SongID = songs.SongID,
                               Title = songs.Title,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               StageName = artist.StageName,
                               BandName = band.BandName,
                               AlbumName = album.AlbumName,
                               Year = album.Year,
                               Genre = songs.Genre,
                               BPM = songs.BPM,
                               Duration = songs.Duration,
                               NumOfListens = songs.NumOfListens,
                               Vocals = songs.Vocals,
                               DateAdded = songs.DateAdded,
                               Favorite = songs.Favorite
                           });
            return View(results.ToList());
        }

        // POST: Albums/AlbumSearchResults
        public async Task<IActionResult> SongSearchResults(string title)
        {
            var results = (from songs in _context.Songs
                           join albums in _context.Albums on songs.AlbumID equals albums.AlbumID into albumJoin
                           from album in albumJoin.DefaultIfEmpty()
                           join artists in _context.RecordingArtists on album.ArtistID equals artists.ArtistID into artistJoin
                           from artist in artistJoin.DefaultIfEmpty()
                           join musicians in _context.Musicians on artist.MusicianID equals musicians.MusicianID into musicianJoin
                           from musician in musicianJoin.DefaultIfEmpty()
                           join groups in _context.Groups on artist.GroupID equals groups.GroupID into groupJoin
                           from groupI in groupJoin.DefaultIfEmpty()
                           join bands in _context.Bands on artist.BandID equals bands.BandID into bandJoin
                           from band in bandJoin.DefaultIfEmpty()
                           where songs.Title.Contains(title)
                           select new SongViewModel()
                           {
                               SongID = songs.SongID,
                               Title = songs.Title,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               StageName = artist.StageName,
                               BandName = band.BandName,
                               AlbumName = album.AlbumName,
                               Year = album.Year,
                               Genre = songs.Genre,
                               BPM = songs.BPM,
                               Duration = songs.Duration,
                               NumOfListens = songs.NumOfListens,
                               Vocals = songs.Vocals,
                               DateAdded = songs.DateAdded,
                               Favorite = songs.Favorite
                           });
            return View("Index", results);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongID,Title,ArtistID,AlbumID,Genre,BPM,Duration,NumOfListens,Vocals,DateAdded,Favorite")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongID,Title,ArtistID,AlbumID,Genre,BPM,Duration,NumOfListens,Vocals,DateAdded,Favorite")] Song song)
        {
            if (id != song.SongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongID == id);
        }
    }
}
