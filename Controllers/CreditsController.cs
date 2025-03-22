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
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Credits
        public async Task<IActionResult> Index()
        {
            var results = (from credits in _context.Credits
                           join musicians in _context.Musicians on credits.MusicianID equals musicians.MusicianID into musicianJoin
                           from musician in musicianJoin.DefaultIfEmpty()
                           join albums in _context.Albums on credits.AlbumID equals albums.AlbumID into albumJoin
                           from album in albumJoin.DefaultIfEmpty()
                           join artists in _context.RecordingArtists on album.ArtistID equals artists.ArtistID into artistJoin
                           from artist in artistJoin.DefaultIfEmpty()
                           select new CreditViewModel()
                           {
                               CreditID = credits.CreditID,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               CreditType = credits.CreditType,
                               AlbumName = album.AlbumName,
                               ArtistID = artist.ArtistID,
                               ArtistStageName = artist.StageName,
                               Year = (int)album.Year,
                               NumOfSongs = (int)album.NumOfSongs

                           });
            return View(results.ToList());
        }

        // POST: Credits/CreditSearchResults
        public async Task<IActionResult> CreditSearchResults(string lastName)
        {

            var results = (from credits in _context.Credits
                           join musicians in _context.Musicians on credits.MusicianID equals musicians.MusicianID into musicianJoin
                           from musician in musicianJoin.DefaultIfEmpty()
                           join albums in _context.Albums on credits.AlbumID equals albums.AlbumID into albumJoin
                           from album in albumJoin.DefaultIfEmpty()
                           join artists in _context.RecordingArtists on album.ArtistID equals artists.ArtistID into artistJoin
                           from artist in artistJoin.DefaultIfEmpty()
                           join bands in _context.Bands on artist.BandID equals bands.BandID into bandJoin
                           from band in bandJoin.DefaultIfEmpty()
                           where musician.LastName.Contains(lastName)
                           select new CreditViewModel()
                           {
                               CreditID = credits.CreditID,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               CreditType = credits.CreditType,
                               AlbumName = album.AlbumName,
                               ArtistID = artist.ArtistID,
                               ArtistStageName = artist.StageName,
                               BandName = band.BandName,
                               Year = (int)album.Year,
                               NumOfSongs = (int)album.NumOfSongs

                           });
            return View("Index", results);
        }

        // GET: Credits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // GET: Credits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Credits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditID,MusicianID,CreditType,AlbumID")] Credit credit)
        {
            //var albumFind = _context.Albums.Where(x => x.AlbumID == credit.AlbumID);
            //Console.WriteLine(albumFind);
            if (ModelState.IsValid)
            {
                _context.Add(credit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(credit);
        }

        // GET: Credits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
            {
                return NotFound();
            }
            return View(credit);
        }

        // POST: Credits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditID,MusicianID,CreditType,AlbumID")] Credit credit)
        {
            if (id != credit.CreditID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.CreditID))
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
            return View(credit);
        }

        // GET: Credits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditID == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            if (credit != null)
            {
                _context.Credits.Remove(credit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditExists(int id)
        {
            return _context.Credits.Any(e => e.CreditID == id);
        }
    }
}
