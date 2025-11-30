using BeFit.Data;
using BeFit.DTOs;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BeFit.Controllers
{
    [Authorize]
    public class WyciskaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public WyciskaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wyciskanies
        public async Task<IActionResult> Index()
        {
            var currentUserId = GetCurrentUserId();
            var userWyciskanieEntries = _context.Wyciskanie
                .Where(b => b.UzytkownikId == currentUserId);

            return View(await userWyciskanieEntries.ToListAsync());
        }

        // GET: Wyciskanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyciskanie = await _context.Wyciskanie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wyciskanie == null || wyciskanie.UzytkownikId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(wyciskanie);
        }

        // GET: Wyciskanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wyciskanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Obciazenie,LiczbaSerii,PowtorzeniaWSerii")] WyciskanieDTO wyciskanieDTO)
        {

            Wyciskanie wyciskanie= new Wyciskanie()
            {
                Id = wyciskanieDTO.Id,
                StartDate = wyciskanieDTO.StartDate,
                EndDate = wyciskanieDTO.EndDate,
                Obciazenie = wyciskanieDTO.Obciazenie,
                LiczbaSerii = wyciskanieDTO.LiczbaSerii,
                PowtorzeniaWSerii = wyciskanieDTO.PowtorzeniaWSerii,
                UzytkownikId = GetCurrentUserId()
            };
            if (ModelState.IsValid)
            {
                _context.Add(wyciskanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(wyciskanie);
        }

        // GET: Wyciskanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyciskanie = await _context.Wyciskanie.FindAsync(id);
            if (wyciskanie == null || wyciskanie.UzytkownikId != GetCurrentUserId())
            {
                return NotFound();
            }
            return View(wyciskanie);
        }

        // POST: Wyciskanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,EndDate,Obciazenie,LiczbaSerii,PowtorzeniaWSerii")] Wyciskanie wyciskanie)
        {
            if (id != wyciskanie.Id)
            {
                return NotFound();
            }
            if (wyciskanie.UzytkownikId != GetCurrentUserId())
            {
                return Forbid();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wyciskanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Bieganie.Any(e => e.Id == wyciskanie.Id))
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
            return View(wyciskanie);
        }

        // GET: Wyciskanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wyciskanie = await _context.Wyciskanie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wyciskanie == null || wyciskanie.UzytkownikId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(wyciskanie);
        }

        // POST: Wyciskanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wyciskanie = await _context.Wyciskanie.FindAsync(id);
            if (wyciskanie.UzytkownikId != GetCurrentUserId())
            {
                return Forbid();
            }
            if (wyciskanie != null)
            {
                _context.Wyciskanie.Remove(wyciskanie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WyciskanieExists(int id)
        {
            return _context.Wyciskanie.Any(e => e.Id == id);
        }
    }
}
