using BeFit.Data;
using BeFit.DTOs;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace BeFit.Controllers
{
    [Authorize]
    public class BieganiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public BieganiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bieganies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bieganie.ToListAsync());
        }

        // GET: Bieganies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bieganie = await _context.Bieganie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bieganie == null)
            {
                return NotFound();
            }

            return View(bieganie);
        }

        // GET: Bieganies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bieganies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Dystans,Obciazenie,UzytkownikId")] BieganieDTO bieganieDTO)
        {

            Bieganie bieganie = new Bieganie()
            {
                Id = bieganieDTO.Id,
                StartDate = bieganieDTO.StartDate,
                EndDate = bieganieDTO.EndDate,
                Dystans = bieganieDTO.Dystans,
                Obciazenie = bieganieDTO.Obciazenie,
                UzytkownikId = GetUserId(),
            };
            if (ModelState.IsValid)
            {
                _context.Add(bieganie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(bieganie);
        }

        // GET: Bieganies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bieganie = await _context.Bieganie.FindAsync(id);
            if (bieganie == null)
            {
                return NotFound();
            }
            return View(bieganie);
        }

        // POST: Bieganies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,EndDate,Dystans,Obciazenie")] Bieganie bieganie)
        {
            if (id != bieganie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bieganie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BieganieExists(bieganie.Id))
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
            return View(bieganie);
        }

        // GET: Bieganies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bieganie = await _context.Bieganie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bieganie == null)
            {
                return NotFound();
            }

            return View(bieganie);
        }

        // POST: Bieganies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bieganie = await _context.Bieganie.FindAsync(id);
            if (bieganie != null)
            {
                _context.Bieganie.Remove(bieganie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BieganieExists(int id)
        {
            return _context.Bieganie.Any(e => e.Id == id);
        }
    }
}
