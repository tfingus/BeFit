namespace BeFit.ViewModels
{
    public class StatsViewModel
    {
        // Nazwa Aktywności (np. "Bieganie", "Wyciskanie")
        public string ActivityName { get; set; } = string.Empty;

        // Ile razy ćwiczenie było wykonane w ciągu ostatnich 4 tygodni
        public int SessionsLast4Weeks { get; set; }

        // Łączna liczba powtórzeń (Sum(Seria * Powtórzenia))
        public long TotalCalculatedReps { get; set; }

        // Maksymalne obciążenie (dla ćwiczeń siłowych)
        public double MaxLoad { get; set; }

        // Średnie obciążenie (dla ćwiczeń siłowych)
        public double AverageLoad { get; set; }

        // Czas trwania (dla ćwiczeń na czas, np. Bieganie/Pływanie)
        public TimeSpan TotalTime { get; set; }
    }
}