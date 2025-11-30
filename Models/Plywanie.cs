using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;
namespace BeFit.Models
{
    public class Plywanie
    {
        public int Id { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data zakończenia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Dystans (w metrach)")]
        public int Dystans { get; set; } // dystans w metrach
        [Display(Name = "Temperatura wody (w °C)")]
        public int TemperaturaWody { get; set; } // temperatura wody w stopniach Celsjusza
        [Display(Name = "Styl pływania")]
        public string Styl { get; set; }
        [Required]
        public string? UzytkownikId { get; set; }
        public virtual AppUser? Uzytkownik { get; set; }
    }
}
