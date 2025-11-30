using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;

namespace BeFit.Models
{
    public class Bieganie
    {
        public int Id { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data zakończenia")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Dystans (w metrach)")]
        public int Dystans { get; set; }
        [Display(Name = "Założone dodatkowe obciążenie (w kg)")]
        public int Obciazenie { get; set; }
        public string UzytkownikId { get; set; }
        [Display(Name = "Created by")]
        public virtual AppUser? Uzytkownik { get; set; }
    }
}

