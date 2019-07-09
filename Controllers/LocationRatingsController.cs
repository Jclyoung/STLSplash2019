using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STLSplash2019.Data;
using STLSplash2019.Models;

namespace STLSplash2019.Controllers
{
    public class LocationRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocationRatings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LocationRatings.Include(l => l.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LocationRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationRating = await _context.LocationRatings
                .Include(l => l.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationRating == null)
            {
                return NotFound();
            }

            return View(locationRating);
        }

        // GET: LocationRatings/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: LocationRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,LocationId,Review")] LocationRating locationRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", locationRating.LocationId);
            return View(locationRating);
        }

        // GET: LocationRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationRating = await _context.LocationRatings.FindAsync(id);
            if (locationRating == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", locationRating.LocationId);
            return View(locationRating);
        }

        // POST: LocationRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating,LocationId,Review")] LocationRating locationRating)
        {
            if (id != locationRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationRatingExists(locationRating.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", locationRating.LocationId);
            return View(locationRating);
        }

        // GET: LocationRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationRating = await _context.LocationRatings
                .Include(l => l.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationRating == null)
            {
                return NotFound();
            }

            return View(locationRating);
        }

        // POST: LocationRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationRating = await _context.LocationRatings.FindAsync(id);
            _context.LocationRatings.Remove(locationRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationRatingExists(int id)
        {
            return _context.LocationRatings.Any(e => e.Id == id);
        }
    }
}
