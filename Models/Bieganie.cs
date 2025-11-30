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
        [Required]
        [Display(Name = "Data rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Data zakończenia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Dystans (w metrach)")]
        public int Dystans { get; set; }
        [Required]
        public string? UzytkownikId { get; set; }
        [Display(Name = "Created by")]
        public virtual AppUser? Uzytkownik { get; set; }
    }
}

