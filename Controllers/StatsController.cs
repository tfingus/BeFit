using BeFit.Data;
using BeFit.Models;
using BeFit.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Controllers
{
    public class StatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Akcja Index (GET)
        public async Task<IActionResult> Index()
        {
            var fourWeeksAgo = DateTime.Now.AddDays(-28);
            var statsList = new List<StatsViewModel>();

            // A. STATYSTYKI DLA BIEGANIA
            var bieganieSessionTimes = await _context.Bieganie
                .Where(b => b.StartDate >= fourWeeksAgo)
                .Select(b => new { b.StartDate, b.EndDate })
                .ToListAsync();

            var bieganieStats = await _context.Bieganie
                .Where(b => b.StartDate >= fourWeeksAgo)
                .GroupBy(b => 1)
                .Select(g => new
                {
                    Count = g.Count(),
                    TotalDistance = g.Sum(b => b.Dystans),
                    MaxDistance = g.Max(b => b.Dystans)
                }).FirstOrDefaultAsync();

            if (bieganieStats != null && bieganieStats.Count > 0)
            {
                // Sumowanie TimeSpan
                TimeSpan totalBieganieTime = new TimeSpan();
                foreach (var session in bieganieSessionTimes)
                {
                    TimeSpan duration = session.EndDate - session.StartDate;
                    totalBieganieTime += duration;
                }

                statsList.Add(new StatsViewModel
                {
                    ActivityName = "Bieganie (Dystans)",
                    SessionsLast4Weeks = bieganieStats.Count,
                    TotalCalculatedReps = (long)bieganieStats.TotalDistance,
                    MaxLoad = bieganieStats.MaxDistance,
                    AverageLoad = bieganieStats.TotalDistance / bieganieStats.Count,
                    TotalTime = totalBieganieTime
                });
            }


            // B. STATYSTYKI DLA PŁYWANIA
            var plywanieSessionTimes = await _context.Plywanie
                  .Where(b => b.StartDate >= fourWeeksAgo)
                  .Select(b => new { b.StartDate, b.EndDate })
                  .ToListAsync();

            var plywanieStats = await _context.Plywanie
                .Where(b => b.StartDate >= fourWeeksAgo)
                .GroupBy(b => 1)
                .Select(g => new
                {
                    Count = g.Count(),
                    TotalDistance = g.Sum(b => b.Dystans),
                    MaxDistance = g.Max(b => b.Dystans)
                }).FirstOrDefaultAsync();

            if (plywanieStats != null && plywanieStats.Count > 0)
            {
                TimeSpan totalPlywanieTime = new TimeSpan();
                foreach (var session in plywanieSessionTimes)
                {
                    TimeSpan duration = session.EndDate - session.StartDate;
                    totalPlywanieTime += duration;
                }

                statsList.Add(new StatsViewModel
                {
                    ActivityName = "Plywanie (Dystans)",
                    SessionsLast4Weeks = plywanieStats.Count,
                    TotalCalculatedReps = (long)plywanieStats.TotalDistance,
                    MaxLoad = plywanieStats.MaxDistance,
                    AverageLoad = plywanieStats.TotalDistance / plywanieStats.Count,
                    TotalTime = totalPlywanieTime
                });
            }

            // C. STATYSTYKI DLA WYCISKANIA
            var wyciskanieSessionTimes = await _context.Wyciskanie
           .Where(b => b.StartDate >= fourWeeksAgo)
           .Select(b => new { b.StartDate, b.EndDate })
           .ToListAsync();

            var wyciskanieStats = await _context.Wyciskanie
                .Where(w => w.StartDate >= fourWeeksAgo)
                .GroupBy(w => 1)
                .Select(g => new
                {
                    Count = g.Count(),
                    TotalReps = g.Sum(w => w.LiczbaSerii * w.PowtorzeniaWSerii),
                    MaxLoad = g.Max(w => w.Obciazenie),
                    AvgLoad = g.Average(w => w.Obciazenie)
                })
                .FirstOrDefaultAsync();

            if (wyciskanieStats != null && wyciskanieStats.Count > 0)
            {
                TimeSpan totalWyciskanieTime = new TimeSpan();
                foreach (var session in wyciskanieSessionTimes)
                {
                    TimeSpan duration = session.EndDate - session.StartDate;
                    totalWyciskanieTime += duration;
                }
                statsList.Add(new StatsViewModel
                {
                    ActivityName = "Wyciskanie (Obciążenie)",
                    SessionsLast4Weeks = wyciskanieStats.Count,
                    TotalCalculatedReps = wyciskanieStats.TotalReps,
                    MaxLoad = wyciskanieStats.MaxLoad,
                    AverageLoad = wyciskanieStats.AvgLoad,
                    TotalTime = TimeSpan.Zero
                });
            }

            return View(statsList);
        }
    }
}