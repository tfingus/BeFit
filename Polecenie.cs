/*
To ćwiczenie stanowi wstęp do bardziej złożonego ćwiczenia - małej aplikacji webowej BeFit.

Na podstawie przykładowego projektu oraz zdobytej wiedzy, stwórz nowy projekt i nazwij go BeFit.
W tym celu wykorzystaj szablon ASP.NET Core MVC. UWAGA! Jako typ uwierzytelnienia wybierz "Pojedyncze konta"!

Tak utworzony szablon aplikacji zawiera już gotowy kontekst bazy danych i podstawowy system użytkowników.
Korzystając z przykładowego kodu z HomeFinances, ustaw w Program.cs, aby projekt łączył się z bazą danych SQLite. 
Należy w tym celu zmodyfikować pliki Program.cs i appsettings.json. Należy również usunąć folder Migrations 
(prawdopodobnie znajduje się w folderze Data).

Następnie zdefiniuj trzy modele.
Jeden model ma opisywać typy ćwiczeń jakie można wykonywać na siłowni.Jedynym parametrem tego modelu jest jego nazwa (i oczywiście Id).
Ustaw wybrane przez siebie ograniczenie długości nazwy.
Drugi model zawiera informację o sesji treningowej użytkownika. Chwilowo nie będziemy go łączyć z użytkownikiem,
ale miejmy to z tyłu głowy. Dwie ważne informacje, które zawiera ten model, to data i czas rozpoczęcia treningu 
oraz data i czas zakończenia treningu. Jeśli potrafisz możesz spróbować zdefiniować w modelu walidator weryfikujący, czy data 
rozpoczęcia nie jest późniejsza niż zakończenia. Nie jest to jednak obowiązkowe, bo wymaga własnej definicji atrybutu.
Trzeci model łączy powyższe dwa. Model ten informuje, jaki typ ćwiczenia został wykonany w jakiej sesji treningowej przez 
jakiego użytkownika (to ostatnie chwilowo pomiń). Ponadto umieść w nim informacje o zastosowanym obciążeniu, liczbie serii i liczbie powtórzeń w serii.
Te trzy modele zarejestruj w kontekście bazy danych i przeprowadź migrację (stwórz i wykonaj). 
Przy pomocy oprogramowania do analizy plików baz danych sqlite, podejrzyj i przeanalizuj stworzoną strukturę bazy. 
 */

/*
To ćwiczenie stanowi kontynuację ćwiczenia z poprzedniej lekcji. Otwieramy więc utworzony już projekt BeFit, w którym mamy trzy stworzone
modele wraz z kontekstem bazy danych. 
Co należy zrobić? W pierwszej kolejności przy pomocy elementów szkieletowych tworzymy kontrolery i widoki
dla podstawowych operacji CRUD. W ten sposób możemy łatwo dodać sobie przykładowe treści do testów. Pamiętaj, że jeszcze nie mamy tutaj systemu
użytkowników (znaczy, mamy, ale nic jeszcze nie robi)! Na co zwracamy uwagę? W formularzach tworzenia i edycji dla modelu opisującego wykonane 
ćwiczenia wraz z parametrami są listy rozwijane. O ile mamy jakieś typy ćwiczeń i sesje ćwiczeniowe, listy te nie są puste, ale są
niefunkcjonalne - wyświetlają id zamiast czegoś czytelnego. Należy to zmienić. W wygenerowanym kontrolerze są cztery miejsca w których tworzone 
są dwa obiekty SelectList. Znajdź je i zmodyfikuj. Możesz posłużyć się dokumentacją, by wiedzieć za co odpowiadają parametry lub spojrzeć
na przykładowy projekt. Następnie sprawdź, czy na pewno w modelach wszystkie pola mają stosownie ustawiony atrybut [Display]. Pola muszą 
mieć przynajmniej nazwę, a najlepiej i opis. Jeśli są dobrze ustawione, będzie to widoczne w formularzach.
Ostatnim, najtrudniejszym, jest stworzenie własnego kontrolera. Tworzymy sobie pusty kontroler StatsController (czyli nie generujemy go 
jako element szkieletowy). Dostosowujemy go, by miał dostęp do kontekstu bazy danych. Następnie tworzymy mu akcję Index (GET), która wyświetli
statystyki wykonanych ćwiczeń. Każdy typ ćwiczeń ma mieć wyświetlone, ile razy w ciągu ostatnich czterech tygodni było dane
ćwiczenie wykonywane, ile łącznie powtórzeń zostało wykonanych (liczba serii * liczba powtórzeń serii, zsumować po wszystkich sesjach) oraz jakie było średnie i maksymalne obciążenie.
By wyświetlić dane stwórz stosowny widok, który wygeneruje odpowiednią tabelkę. Jeśli taka jest Twoja preferencja, stwórz sobie model
do przechowywania statystyk. Ważne jest to, by nie rejestrować go w bazie danych - model musi być generowany dynamicznie, na żywo, przez Entity Framework.
W kolejnych lekcjach dostosujemy ten projekt do systemu użytkowników. 
 * */

/*
 * 
 * Kontynuujemy pracę z projektem BeFit. Dziś dodamy do niego użytkowników.
 * Ze względu na to, że już wcześniej pracowaliśmy nad tym projektem i prawdopodobnie 
 * możemy mieć jakieś dane w bazie, zaleca się usunąć bazę danych i wszystkie migracje. 
 * Za chwilę dokonamy modyfikacji i wtedy stworzymy nową migrację.
 * W pierwszej kolejności stwórz model użytkownika. Nazwij go jak chcesz, byle dziedziczył 
 * po IdenitityUser (jak w poprzedniej lekcji) i użyj go konsekwentnie we wszystkich miejscach kodu.
 * Następnie powiąż model sesji treningowych i ćwiczeń wykonanych w tych sesjach z modelem użytkownika.
 * Nazwij połączenie dowolnie. Stwórz migrację i zaktualizuj (stwórz) bazę danych.
 * Do kontrolerów dla sesji i wykonanych ćwiczeń dodaj metodę pobierającą id użytkownika (możesz skopiować z przykładowego projektu).
 * W akcjach Create w obu wymienionych kontrolerach zastosuj wiązanie modeli z aktualnie zalogowanym użytkownikiem.
 * W tym celu musisz stworzyć odpowiednie modele DTO.
 * Możesz przetestować efekty swoich działań i sprawdzić je w bazie danych.
 */

/*
 
private string GetUserId()
{
     return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}

Powyższa metoda zwracać będzie id użytkownika, o ile jakiś jest zalogowany.
W przeciwnym wypadku będzie to pusty string. Jak widać, nie jest to ani trochę intuicyjne jak na tak podstawową funkcjonalność.
Znacznie prostsza metoda o nazwie analogicznej do powyższej została usunięta w ASP.NET Core 6. Należy o tym pamiętać, wyszukując informacje w internecie.
 */

