using System.ComponentModel.DataAnnotations;
using BeFit.Models;

namespace BeFit.DTOs
{
    public class WyciskanieDTO
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
        [Display(Name = "Obciążenie (w kg)")]
        public int Obciazenie { get; set; }
        [Required]
        [Display(Name = "Liczba serii")]
        public int LiczbaSerii { get; set; }
        [Required]
        [Display(Name = "Powtórzenia w serii")]
        public int PowtorzeniaWSerii { get; set; }

        public WyciskanieDTO() { }
        public WyciskanieDTO(Wyciskanie wyciskanie)
        {
            Id = wyciskanie.Id;
            StartDate = wyciskanie.StartDate;
            EndDate = wyciskanie.EndDate;
            Obciazenie = wyciskanie.Obciazenie;
            LiczbaSerii = wyciskanie.LiczbaSerii;
            PowtorzeniaWSerii = wyciskanie.PowtorzeniaWSerii;
        }


    }
}