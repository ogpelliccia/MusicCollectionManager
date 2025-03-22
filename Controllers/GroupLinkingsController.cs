using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicCollectionManager.Data;
using MusicCollectionManager.Models;

namespace MusicCollectionManager.Controllers
{
    public class GroupLinkingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupLinkingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroupLinkings
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupLinkings.ToListAsync());
        }

        // GET: GroupLinkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupLinking = await _context.GroupLinkings
                .FirstOrDefaultAsync(m => m.LinkID == id);
            if (groupLinking == null)
            {
                return NotFound();
            }

            return View(groupLinking);
        }

        // GET: GroupLinkings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupLinkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkID,ArtistID,GroupID")] GroupLinking groupLinking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupLinking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupLinking);
        }

        // GET: GroupLinkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupLinking = await _context.GroupLinkings.FindAsync(id);
            if (groupLinking == null)
            {
                return NotFound();
            }
            return View(groupLinking);
        }

        // POST: GroupLinkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkID,ArtistID,GroupID")] GroupLinking groupLinking)
        {
            if (id != groupLinking.LinkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupLinking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupLinkingExists(groupLinking.LinkID))
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
            return View(groupLinking);
        }

        // GET: GroupLinkings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupLinking = await _context.GroupLinkings
                .FirstOrDefaultAsync(m => m.LinkID == id);
            if (groupLinking == null)
            {
                return NotFound();
            }

            return View(groupLinking);
        }

        // POST: GroupLinkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupLinking = await _context.GroupLinkings.FindAsync(id);
            if (groupLinking != null)
            {
                _context.GroupLinkings.Remove(groupLinking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupLinkingExists(int id)
        {
            return _context.GroupLinkings.Any(e => e.LinkID == id);
        }
    }
}
