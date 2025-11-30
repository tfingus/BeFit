using System.ComponentModel.DataAnnotations;
using BeFit.Models;

namespace BeFit.DTOs
{
    public class BieganieDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data i godzina rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data i godzina zakończenia")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Dystans (w metrach)")]
        public int Dystans { get; set; }
        public BieganieDTO() { }
        public BieganieDTO(Bieganie bieganie)
        {
            Id = bieganie.Id;
            StartDate = bieganie.StartDate;
            EndDate = bieganie.EndDate;
            Dystans = bieganie.Dystans;
        }


    }
}