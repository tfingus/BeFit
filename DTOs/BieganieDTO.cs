using System.ComponentModel.DataAnnotations;
using BeFit.Models;

namespace BeFit.DTOs
{
    public class BieganieDTO
    {
        public int Id { get; set; }
        [Display(Name = "Data i godzina rozpoczęcia")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data i godzina zakończenia")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Dystans (w metrach)")]
        public int Dystans { get; set; }
        [Display(Name = "Założone dodatkowe obciążenie (w kg)")]
        public int Obciazenie { get; set; }
        public BieganieDTO() { }
        public BieganieDTO(Bieganie bieganie)
        {
            Id = bieganie.Id;
            StartDate = bieganie.StartDate;
            EndDate = bieganie.EndDate;
            Dystans = bieganie.Dystans;
            Obciazenie = bieganie.Obciazenie;
        }


    }
}