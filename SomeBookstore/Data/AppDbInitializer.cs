using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBiulder)
        {
            using (var serviceScope = applicationBiulder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "J.R.R. Tolkien",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/authors/3216/702088-352x500.jpg",
                            Description = @"Brytyjski pisarz oraz profesor filologii klasycznej i literatury staroangielskiej na University of Oxford. Jako autor powieści Władca Pierścieni, której akcja rozgrywa się w mitycznym świecie Śródziemia, spopularyzował literaturę fantasy.
                                Jest autorem wielu dzieł rozgrywających się w Śródziemiu: powieści Hobbit, czyli tam i z powrotem, Władca Pierścieni, Silmarillion (nieuporządkowanego jako spójna całość narracyjna przez Ronalda – książkę przygotował do druku jego syn Christopher Tolkien) oraz kilku krótkich form, opowiadań niezwiązanych lub luźno związanych z wielką mitologią, tzw. Legendarium Śródziemia (zawartej w 12-tomowej History of the Middle-earth, opracowanej i wydanej przez Christophera Tolkiena).
                                Opublikował ponad 100 prac z dziedziny filologii i literatury dawnej, współpracował przy powstaniu największego słownika języka angielskiego, wydawanego zaraz po I wojnie, Oxford English Dictionary. Znał (w różnym stopniu) ponad 30 języków m.in. łacinę, nordycki, staroislandzki, anglosaski czy staroirlandzki."
                        },
                        new Author()
                        {
                            FullName = "Stephen King",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/authors/13997/849814-352x500.jpg",
                            Description = @"Amerykański powieściopisarz, głównie literatury grozy. W przeszłości publikował pod pseudonimem Richard Bachman, raz jako John Swithen.
                                Mistrz horroru. Eksperymentator internetowy. Rzemieślnik i artysta. Jeden z najbogatszych pisarzy świata (zarabia rocznie średnio 50 mln dolarów). Każda jego książka trafia natychmiast po premierze na szczyty list bestsellerów, a zanim powstanie, wytwórnie filmowe biją się o prawa do jej ekranizacji. Jest przy tym kochany przez rodaków jak mało który literat: jego kariera to odzwierciedlenie amerykańskiego mitu sukcesu - od pucybuta do prezydenta. A w tym przypadku - od pracownika miejskiej pralni do króla literatury popularnej."
                        },
                        new Author()
                        {
                            FullName = "Remigiusz Mróz",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/authors/82094/914988-352x500.jpg",
                            Description = @"Polski pisarz, autor powieści kryminalnych oraz cyklu publicystycznego „Kurs pisania”.
                                Ukończył z wyróżnieniem Akademię Leona Koźmińskiego w Warszawie, gdzie uzyskał stopień naukowy doktora nauk prawnych.
                                Laureat Nagrody Czytelników Wielkiego Kalibru z 2016 roku za powieść pt. „Kasacja”. W 2017 roku ujawnił się jako Ove Løgmansbø, autor kolejnych trzech powieści."
                        },
                        new Author()
                        {
                            FullName = "Andrzej Sapkowski",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/authors/3291/788213-352x500.jpg",
                            Description = @"Urodził się i mieszka w Łodzi. Od 9 lipca 2008 roku jest honorowym obywatelem tego miasta. Jest absolwentem XXI Liceum Ogólnokształcącego im. Bolesława Prusa w Łodzi oraz Uniwersytetu Łódzkiego (handel zagraniczny, 1972). Początkowo pracował w handlu zagranicznym – handlował futrami w firmie „Skórimpex”.
                                Karierę literacką zaczynał jako tłumacz, przekładając na język polski opowiadanie Słowa Guru Cyryla M. Kornblutha w „Fantastyce”. Popularność zdobył cyklem opowiadań i pięciotomową sagą o wiedźminie – pierwsze opowiadanie „Wiedźmin”, debiut pisarza, ukazało się w grudniu 1986 w miesięczniku „Fantastyka”, jako laureat III nagrody w konkursie literackim ogłoszonym przez czasopismo. Oprócz tego wydał esej o Rycerzach Okrągłego Stołu Świat króla Artura. Maladie, leksykon miłośnika fantasy Rękopis znaleziony w Smoczej Jaskini, poradnik dla osób zaczynających grać w RPG pt. Oko Yrrhedesa, powieści z cyklu o Reinmarze z Bielawy (Trylogia husycka), powieść Żmija oraz wiele opowiadań i artykułów w czasopismach i zbiorach opowiadań."
                        },
                        new Author()
                        {
                            FullName = "Jennifer L. Armentrout",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/authors/63908/787992-352x500.jpg",
                            Description = "Amerykańska pisarka, autora romansów i science-fiction. Ma na swoim koncie kilka książek z listy bestsellerów New York Timesa. Wydaje książki zarówno tradycyjnie poprzez duże wydawnictwa jak HarperCollins przez niezależne firmy, a nawet self-publishing - nazywa się ją pisarzem \"hybrydowym\". Jest bardzo aktywna, zgodnie z jej słowem pisze po osiem godzin dziennie."
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                        {
                            Name = "Wydawnictwo Iskry",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/publishers/4313/4313-b.jpg",
                            Description = @"Swą nazwą nawiązują do ukazującego się przed wojną, w latach 1923–1939, tygodnika „Iskry” oraz znanej serii książek „Biblioteka Iskier”. Jako wydawnictwo istnieją od 1952 roku, a od 1992 są oficyną prywatną, której prezesem jest dr Wiesław Uchański."
                        },
                        new Publisher()
                        {
                            Name = "Albatros",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/publishers/417/417-b.jpg",
                            Description = @"Wydawnictwo Albatros działa od listopada 1994 roku. Zostało założone przez miłośnika książek Andrzeja Kuryłowicza."
                        },
                        new Publisher()
                        {
                            Name = "Czwarta Strona",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/publishers/11085/11085-b.jpg",
                            Description = @"Powstały w 2014 r. - jedno z najmłodszych polskich wydawnictw. Jest częścią Wydawnictwa Poznańskiego.
                                Zajmują się wydawaniem m.in. literatury pięknej, historycznej, biografii, kryminałów, poradników, powieści fantastycznych, horrorów i thrillerów. Skupia się na nowościach.
                                Wśród ich autorów znajdują się tacy popularni pisarze jak George R.R. Martin czy Remigiusz Mróz."
                        },
                        new Publisher()
                        {
                            Name = "superNOWA",
                            ImageUrl = "https://s.lubimyczytac.pl/upload/publishers/12399/12399-b.jpg",
                            Description = "SUPERNOWA - Niezależna Oficyna Wydawnicza NOWA powstała jesienią 1977. Drukowała zakazane przez komunistyczne władze arcydzieła światowej literatury. Nie stroniła od fantastyki. Jej nakładem ukazały się m.in. George'a Orwella, Kurta Vonneguta, Eugeniusza Zamiatina, Aleksandra Zinowiewa i Tadeusza Konwickiego, którego \"Mała apokalipsa\" weszła do kanonu lektur szkolnych."
                        }
                    });
                    context.SaveChanges();

                    if (!context.Books.Any())
                    {
                        context.Books.AddRange(new List<Book>() {
                            new Book ()
                            {
                                Name = "Hobbit, czyli tam i z powrotem",
                                Description = "Najnowsze wydanie klasycznego dzieła Tolkiena. Hobbit to istota większa od liliputa, mniejsza jednak od krasnala. Fantastyczny, przemyślany do najdrobniejszych szczegółów świat z powieści Tolkiena jest również jego osobistym tworem, a pod barwną fasadą nietrudno się dopatrzyć głębszego sensu i pewnych analogii do współczesności.",
                                Price = 40,
                                ImageUrl = "https://img.literia.pl/webp/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/2/9/29760af07e07174d63010c4acd67ee32_4.jpg",
                                ReleaseDate = DateTime.Now.AddDays(-432),
                                AuthorId = 1,
                                PublisherId = 1,
                                BookCategory = Enums.BookCategory.Fantasy,
                                AverageRating = 8.3m,
                                Reviews = new List<Review>()
                                {
                                    new Review()
                                    {
                                        Rating = 8,
                                        ReviewerName = "Edyta",
                                        Text = "Uwielbiam Tolkiena. Świetnie się czyta. Co za wyobraźnia..."
                                    },
                                    new Review()
                                    {
                                        Rating = 8,
                                        ReviewerName = "Krzychu",
                                        Text = "Bardzo przyjemna książka, czytam pierwszy raz i bardzo mi się podobała. Lekka w odbiorze, klasyka fantastyki. Polecam serdecznie."
                                    },
                                    new Review()
                                    {
                                        Rating = 9,
                                        ReviewerName = "Franek",
                                        Text = "Bardzo dobrze zbudowany świat i bohaterowie. Jedno z trzech (Wiedźmin, Diuna, LOTR) universum, które oceniam na 9/10 za całokształt."
                                    }
                                }
                            },
                            new Book ()
                            {
                                Name = "Ostatnia misja Gwendy",
                                Description = "Mistrzowie grozy, Stephen King i Richard Chizmar, ponownie zabierają czytelników do miasteczka Castle Rock w stanie Maine, a stamtąd w przestrzeń pozaziemską, gdzie Gwendy będzie miała do wykonania doniosłą i tajemniczą misję ocalenia świata – być może nie tylko tego, który znamy.",
                                Price = 35,
                                ImageUrl = "https://s.lubimyczytac.pl/upload/books/4996000/4996831/950134-352x500.jpg",
                                ReleaseDate = DateTime.Now.AddDays(-75),
                                AuthorId = 2,
                                PublisherId = 2,
                                BookCategory = Enums.BookCategory.ScienceFiction,
                                AverageRating = 10,
                                Reviews = new List<Review>()
                                {
                                    new Review()
                                    {
                                        Rating = 10,
                                        ReviewerName = "Janek",
                                        Text = "Uwielbiam."
                                    }
                                }
                            },
                            new Book ()
                            {
                                Name = "Kasacja",
                                Description = @"Manipulacje, intrygi i bezwzględny, ale też fascynujący prawniczy świat…
                                    Syn biznesmena zostaje oskarżony o zabicie dwóch osób. Sprawa wydaje się oczywista. Potencjalny winowajca spędza bowiem 10 dni zamknięty w swoim mieszkaniu z ciałami ofiar.",
                                Price = 25,
                                ImageUrl = "https://s.lubimyczytac.pl/upload/books/4904000/4904710/768544-352x500.jpg",
                                ReleaseDate = DateTime.Now.AddDays(-35),
                                AuthorId = 3,
                                PublisherId = 3,
                                BookCategory = Enums.BookCategory.Kryminał,
                                AverageRating = 7,
                                Reviews = new List<Review>()
                                {
                                    new Review()
                                    {
                                        Rating = 7,
                                        ReviewerName = "Janek",
                                        Text = "Może być"
                                    }
                                }
                            },
                            new Book ()
                            {
                                Name = "Ostatnie życzenie",
                                Description = @"Później mówiono, że człowiek ów nadszedł od północy, od Bramy Powroźniczej. Nie był stary, ale włosy miał zupełnie białe. Kiedy ściągnął płaszcz, okazało się, że na pasie za plecami ma miecz.
                                    Białowłosego przywiodło do miasta królewskie orędzie: trzy tysiące orenów nagrody za odczarowanie nękającej mieszkańców Wyzimy strzygi.",
                                Price = 39,
                                ImageUrl = "https://s.lubimyczytac.pl/upload/books/240000/240310/490965-352x500.jpg",
                                ReleaseDate = DateTime.Now.AddDays(-99),
                                AuthorId = 4,
                                PublisherId = 4,
                                BookCategory = Enums.BookCategory.Fantasy
                            },
                            new Book ()
                            {
                                Name = "Krew i popiół",
                                Description = @"Poppy jest Panną. Jej życie jest pełne samotności. Nikt nie może jej dotknąć. Tylko garstka wybrańców może zobaczyć jej twarz albo z nią porozmawiać. Jej egzystencja jest pozbawiona wszelkiej przyjemności. Poświęcona bogom, ma tylko jedno zadanie - przygotować się do Ascendencji, rytuału, który ma zapoczątkować nową erę.
Jednak Poppy dużo lepiej czuje się w towarzystwie swoich strażników niż dam dworu i kapłanek. Gdyby mogła, mieczem i łukiem broniłaby swoich bliskich przed niebezpieczeństwem zza Zapory. Dobrze wie, jakie potwory kryją się za nią w magicznej mgle. Niestety, nie ma żadnego wpływu na swoją rolę w zbliżającym się obrządku. Mimo to, Poppy jest gotowa podjąć ryzyko.",
                                Price = 55,
                                ImageUrl = "https://s.lubimyczytac.pl/upload/books/4994000/4994584/946336-352x500.jpg",
                                ReleaseDate = DateTime.Now.AddDays(-21),
                                AuthorId = 5,
                                PublisherId = 4,
                                BookCategory = Enums.BookCategory.Fantasy
                            },
                            new Book ()
                            {
                                Name = "Projekt Riese",
                                Description = "Riese. Największy projekt nazistowskich Niemiec, którego przeznaczenie wciąż pozostaje nieznane. Niegdyś być może podziemne miasto, arka przetrwania lub fabryka, w której pracowano nad bronią jądrową – dziś atrakcja turystyczna w Górach Sowich.",
                                Price = 25,
                                ImageUrl = "https://s.lubimyczytac.pl/upload/books/4998000/4998407/953017-352x500.jpg",
                                ReleaseDate = DateTime.Now.AddDays(-55),
                                AuthorId = 3,
                                PublisherId = 3,
                                BookCategory = Enums.BookCategory.Fantasy
                            }
                        });
                        context.SaveChanges();
                    }
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                try
                {
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    string adminUserEmail = "admin@test.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new ApplicationUser()
                        {
                            FullName = "Admin",
                            UserName = "admin-user",
                            Email = adminUserEmail,
                            EmailConfirmed = true
                        };
                        var adminResult = await userManager.CreateAsync(newAdminUser, "Admin123!@#");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }

                    string appUserEmail = "user@test.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new ApplicationUser()
                        {
                            FullName = "Test User",
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(newAppUser, "User123!@#");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            }
        }
    }
}
