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
    public class RecordingArtistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecordingArtistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecordingArtists
        public async Task<IActionResult> Index()
        {            
            var results = (from artists in _context.RecordingArtists
                           join musicians in _context.Musicians on artists.MusicianID equals musicians.MusicianID into musJoin
                           from musician in musJoin.DefaultIfEmpty()
                           join groups in _context.Groups on artists.GroupID equals groups.GroupID into groupJoin
                           from indGroup in groupJoin.DefaultIfEmpty()
                           join bands in _context.Bands on artists.BandID equals bands.BandID into bandJoin
                           from band in bandJoin.DefaultIfEmpty()
                           select new ArtistViewModel()
                           {
                               ArtistID = artists.ArtistID,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               StageName = artists.StageName,
                               BandName = band.BandName
                           });
            return View(results.ToList());
        }

        // POST: Artists/ArtistSearchResults
        public async Task<IActionResult> ArtistSearchResults(string lastName)
        {
            var results = (from artists in _context.RecordingArtists
                           join musicians in _context.Musicians on artists.MusicianID equals musicians.MusicianID into musJoin
                           from musician in musJoin.DefaultIfEmpty()
                           join groups in _context.Groups on artists.GroupID equals groups.GroupID into groupJoin
                           from indGroup in groupJoin.DefaultIfEmpty()
                           join bands in _context.Bands on artists.BandID equals bands.BandID into bandJoin
                           from band in bandJoin.DefaultIfEmpty()
                           where musician.LastName.Contains(lastName)
                           select new ArtistViewModel()
                           {
                               ArtistID = artists.ArtistID,
                               FirstName = musician.FirstName,
                               LastName = musician.LastName,
                               StageName = artists.StageName,
                               BandName = band.BandName
                           });
            return View("Index", results);
        }

        // GET: RecordingArtists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordingArtist = await _context.RecordingArtists
                .FirstOrDefaultAsync(m => m.ArtistID == id);
            if (recordingArtist == null)
            {
                return NotFound();
            }

            return View(recordingArtist);
        }

        // GET: RecordingArtists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordingArtists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistID,MusicianID,GroupID,StageName,BandID")] RecordingArtist recordingArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recordingArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recordingArtist);
        }

        // GET: RecordingArtists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordingArtist = await _context.RecordingArtists.FindAsync(id);
            if (recordingArtist == null)
            {
                return NotFound();
            }
            return View(recordingArtist);
        }

        // POST: RecordingArtists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistID,MusicianID,GroupID,StageName,BandID")] RecordingArtist recordingArtist)
        {
            if (id != recordingArtist.ArtistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordingArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordingArtistExists(recordingArtist.ArtistID))
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
            return View(recordingArtist);
        }

        // GET: RecordingArtists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordingArtist = await _context.RecordingArtists
                .FirstOrDefaultAsync(m => m.ArtistID == id);
            if (recordingArtist == null)
            {
                return NotFound();
            }

            return View(recordingArtist);
        }

        // POST: RecordingArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordingArtist = await _context.RecordingArtists.FindAsync(id);
            if (recordingArtist != null)
            {
                _context.RecordingArtists.Remove(recordingArtist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordingArtistExists(int id)
        {
            return _context.RecordingArtists.Any(e => e.ArtistID == id);
        }
    }
}
