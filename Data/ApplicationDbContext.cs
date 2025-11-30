using BeFit.Models;
using BeFit.Controllers;
using BeFit.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BeFit.Models.Bieganie> Bieganie { get; set; } = default!;
        public DbSet<BeFit.Models.Plywanie> Plywanie { get; set; } = default!;
        public DbSet<BeFit.Models.Wyciskanie> Wyciskanie { get; set; } = default!;

    }
}
