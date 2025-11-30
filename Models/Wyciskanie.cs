using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;

namespace BeFit.Models
{
    public class Wyciskanie
    {
        public int Id { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data zakończenia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Obciążenie (w kg)")]
        public int Obciazenie { get; set; }
        [Display(Name = "Liczba serii")]
        public int LiczbaSerii { get; set; }
        [Display(Name = "Powtórzenia w serii")]
        public int PowtorzeniaWSerii { get; set; }
        [Required]
        public string UzytkownikId { get; set; }
        public virtual AppUser? Uzytkownik { get; set; }
    }
}
