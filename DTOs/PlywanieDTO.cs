using System.ComponentModel.DataAnnotations;
using BeFit.Models;

namespace BeFit.DTOs
{
    public class PlywanieDTO
    {
        public int Id { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data zakończenia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Dystans (w metrach)")]
        public int Dystans { get; set; } // dystans w metrach
        [Display(Name = "Temperatura wody (w °C)")]
        public int TemperaturaWody { get; set; } // temperatura wody w stopniach Celsjusza
        [Display(Name = "Styl pływania")]
        public string Styl { get; set; }
        public PlywanieDTO() { }
        public PlywanieDTO(Plywanie plywanie)
        {
            Id = plywanie.Id;
            StartDate = plywanie.StartDate;
            EndDate = plywanie.EndDate;
            Dystans = plywanie.Dystans;
            TemperaturaWody = plywanie.TemperaturaWody;
            Styl = plywanie.Styl;
        }


    }
}