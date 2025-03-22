using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.VisualBasic;
using MusicCollectionManager.Data;
using MusicCollectionManager.Models;
using MusicCollectionManager.ViewModels;

namespace MusicCollectionManager.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlbumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            var results = (from albums in _context.Albums
                           join artists in _context.RecordingArtists on albums.ArtistID equals artists.ArtistID into artistJoin
                           from artist in artistJoin.DefaultIfEmpty()
                           join musicians in _context.Musicians on artist.MusicianID equals musicians.MusicianID into musicianJoin
                           from musician in musicianJoin.DefaultIfEmpty()
                           join groups in _context.Groups on artist.GroupID equals groups.GroupID into groupJoin
                           from groupI in groupJoin.DefaultIfEmpty()
                           join bands in _context.Bands on artist.BandID equals bands.BandID into bandJoin
                           from band in bandJoin.DefaultIfEmpty()
                           select new AlbumViewModel()
                           {
                               AlbumID = albums.AlbumID,
                               AlbumName = albums.AlbumName,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               StageName = artist.StageName,
                               BandName = band.BandName,
                               RecordLabel = albums.RecordLabel,
                               Year = (int)albums.Year,
                               NumOfSongs = (int)albums.NumOfSongs,
                               TotalDuration = albums.TotalDuration
                           });
            return View(results.ToList());
        }

        // POST: Albums/AlbumSearchResults
        public async Task<IActionResult> AlbumSearchResults(string albumName)
        {
            var results = (from albums in _context.Albums
                           join artists in _context.RecordingArtists on albums.ArtistID equals artists.ArtistID
                           join musicians in _context.Musicians on artists.MusicianID equals musicians.MusicianID
                           join groups in _context.Groups on artists.GroupID equals groups.GroupID into groupJoin
                           from band in groupJoin.DefaultIfEmpty()
                           where albums.AlbumName.Contains(albumName)
                           select new AlbumViewModel()
                           {
                               AlbumID = albums.AlbumID,
                               AlbumName = albums.AlbumName,
                               FirstName = musicians.FirstName,
                               LastName = musicians.LastName,
                               StageName = artists.StageName,
                               RecordLabel = albums.RecordLabel,
                               Year = (int)albums.Year,
                               NumOfSongs = (int)albums.NumOfSongs,
                               TotalDuration = albums.TotalDuration
                           });
            return View("Index", results);
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumID,AlbumName,ArtistID,GroupID,RecordLabel,Year,NumOfSongs,TotalDuration")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumID,AlbumName,ArtistID,GroupID,RecordLabel,Year,NumOfSongs,TotalDuration")] Album album)
        {
            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
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
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumID == id);
        }
    }
}
