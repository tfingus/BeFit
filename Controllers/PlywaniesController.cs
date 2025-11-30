using BeFit.Data;
using BeFit.DTOs;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BeFit.Controllers
{
    [Authorize]
    public class PlywaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public PlywaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plywanies
        public async Task<IActionResult> Index()
        {
            var currentUserId = GetCurrentUserId();
            var userPlywanieEntries = _context.Plywanie
                .Where(b => b.UzytkownikId == currentUserId);

            return View(await userPlywanieEntries.ToListAsync());
        }

        // GET: Plywanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plywanie = await _context.Plywanie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plywanie == null || plywanie.UzytkownikId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(plywanie);
        }

        // GET: Plywanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plywanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Dystans,TemperaturaWody,Styl")] PlywanieDTO plywanieDTO)
        {

            Plywanie plywanie = new Plywanie()
            {
                Id = plywanieDTO.Id,
                StartDate = plywanieDTO.StartDate,
                EndDate = plywanieDTO.EndDate,
                Dystans = plywanieDTO.Dystans,
                TemperaturaWody = plywanieDTO.TemperaturaWody,
                Styl = plywanieDTO.Styl,
                UzytkownikId = GetCurrentUserId()
            };
            if (ModelState.IsValid)
            {
                _context.Add(plywanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(plywanie);
        }

        // GET: Plywanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plywanie = await _context.Plywanie.FindAsync(id);
            if (plywanie == null || plywanie.UzytkownikId != GetCurrentUserId())
            {
                return NotFound();
            }
            return View(plywanie);
        }

        // POST: Plywanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,EndDate,Dystans,TemperaturaWody,Styl")] Plywanie plywanie)
        {
            if (id != plywanie.Id)
            {
                return NotFound();
            }
            if (plywanie.UzytkownikId != GetCurrentUserId())
            {
                return Forbid();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plywanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Plywanie.Any(e => e.Id == plywanie.Id))
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
            return View(plywanie);
        }

        // GET: Plywanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plywanie = await _context.Plywanie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plywanie == null || plywanie.UzytkownikId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(plywanie);
        }

        // POST: Plywanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plywanie = await _context.Plywanie.FindAsync(id);
            if (plywanie.UzytkownikId != GetCurrentUserId())
            {
                return Forbid();
            }
            if (plywanie != null)
            {
                _context.Plywanie.Remove(plywanie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlywanieExists(int id)
        {
            return _context.Plywanie.Any(e => e.Id == id);
        }
    }
}
