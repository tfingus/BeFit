using System.ComponentModel.DataAnnotations;
using BeFit.Models;

namespace BeFit.DTOs
{
    public class BieganieDTO
    {
        public int Id { get; set; }
        [Display(Name = "Data i godzina rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data i godzina zakończenia")]
        public DateTime EndDate { get; set; }
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