using cinemawebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemawebapp.Data
{
    public static class MovieSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(

                // ── NOW IN THEATERS ──────────────────────────────────────

                new Movie
                {
                    Id = 1,
                    Title = "The Dark Knight",
                    Genre = "Action / Crime",
                    DurationMinutes = 152,
                    AgeRating = "13+",
                    Description = "WELCOME TO A WORLD WITHOUT RULES." + Environment.NewLine +
                                  "Batman raises the stakes in his war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to dismantle the remaining criminal organizations that plague the streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as the Joker.",
                    Director = "Christopher Nolan",
                    ImagePath = "/images/negruvoda.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/EXeTwQWrcwY",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 2,
                    Title = "Se7en",
                    Genre = "Crime / Thriller",
                    DurationMinutes = 127,
                    AgeRating = "18+",
                    Description = "GLUTTONY. GREED. SLOTH. ENVY. WRATH. PRIDE. LUST." + Environment.NewLine +
                                  "Two homicide detectives are on a desperate hunt for a serial killer whose crimes are based on the seven deadly sins in this dark and haunting film that takes viewers from the tortured remains of one victim to the next. The seasoned Det. Somerset researches each sin in an effort to get inside the killer's mind, while his novice partner, Mills, scoffs at his efforts to unravel the case.",
                    Director = "David Fincher",
                    ImagePath = "/images/Se7en.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/znmZoVkCjpI",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Pianist",
                    Genre = "Drama / War",
                    DurationMinutes = 150,
                    AgeRating = "15+",
                    Description = "MUSIC WAS HIS PASSION. SURVIVAL WAS HIS MASTERPIECE." + Environment.NewLine +
                                  "The true story of pianist Władysław Szpilman's experiences in Warsaw during the Nazi occupation. When the Jews of the city find themselves forced into a ghetto, Szpilman finds work playing in a café; and when his family is deported in 1942, he stays behind, works for a while as a laborer, and eventually goes into hiding in the ruins of the war-torn city.",
                    Director = "Roman Polanski",
                    ImagePath = "/images/ThePianist.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/BFwGqLa_oAo",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 4,
                    Title = "Parasite",
                    Genre = "Thriller / Drama",
                    DurationMinutes = 132,
                    AgeRating = "15+",
                    Description = "ACT LIKE YOU OWN THE PLACE." + Environment.NewLine +
                                  "All unemployed, Ki-taek's family takes peculiar interest in the wealthy and glamorous Parks for their livelihood until they get entangled in an unexpected incident.",
                    Director = "Bong Joon-ho",
                    ImagePath = "/images/Parasite.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/5xH0HfJHsaY",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 5,
                    Title = "WALL-E",
                    Genre = "Animation / Sci-Fi",
                    DurationMinutes = 98,
                    AgeRating = "G",
                    Description = "AFTER 700 YEARS OF DOING WHAT HE WAS BUILT FOR, HE'LL DISCOVER WHAT HE WAS MEANT FOR." + Environment.NewLine +
                                  "After hundreds of lonely years doing what he was built for, WALL·E discovers a new purpose in life when he meets a sleek search robot named EVE. EVE comes to realize that WALL·E has inadvertently stumbled upon the key to the planet's future, and races back to space to report her findings. Meanwhile, WALL·E chases EVE across the galaxy and sets into motion one of the most imaginative adventures ever brought to the big screen.",
                    Director = "Andrew Stanton",
                    ImagePath = "/images/WALL·E.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/alIq_wG9FNk",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 6,
                    Title = "Cars",
                    Genre = "Animation / Comedy",
                    DurationMinutes = 116,
                    AgeRating = "G",
                    Description = "AHHH… IT'S GOT THAT NEW MOVIE SMELL." + Environment.NewLine +
                                  "Lightning McQueen, a hotshot rookie race car driven to succeed, discovers that life is about the journey, not the finish line, when he finds himself unexpectedly detoured in the sleepy Route 66 town of Radiator Springs. On route across the country to the big Piston Cup Championship in California to compete against two seasoned pros, McQueen gets to know the town's offbeat characters.",
                    Director = "John Lasseter",
                    ImagePath = "/images/Cars.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/fwLwaihdSo8",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 7,
                    Title = "Taxi Driver",
                    Genre = "Crime / Drama",
                    DurationMinutes = 114,
                    AgeRating = "18+",
                    Description = "ON EVERY STREET IN EVERY CITY, THERE'S A NOBODY WHO DREAMS OF BEING SOMEBODY." + Environment.NewLine +
                                  "Suffering from insomnia, disturbed loner Travis Bickle takes a job as a New York City cabbie, haunting the streets nightly, growing increasingly detached from reality as he dreams of cleaning up the filthy city.",
                    Director = "Martin Scorsese",
                    ImagePath = "/images/TaxiDriver.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/T5IligQP7Fo",
                    IsUpcoming = false
                },
                new Movie
                {
                    Id = 8,
                    Title = "Pan's Labyrinth",
                    Genre = "Fantasy / Drama",
                    DurationMinutes = 118,
                    AgeRating = "15+",
                    Description = "INNOCENCE HAS A POWER EVIL CANNOT IMAGINE." + Environment.NewLine +
                                  "In post-civil war Spain, 10-year-old Ofelia moves with her pregnant mother to live under the control of her cruel stepfather. Drawn into a mysterious labyrinth, she meets a faun who reveals that she may be a lost princess from an underground kingdom. To return to her true father, she must complete a series of surreal and perilous tasks that blur the line between reality and fantasy.",
                    Director = "Guillermo del Toro",
                    ImagePath = "/images/Pan’sLabyrinth.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/oOQV8gg9b5o",
                    IsUpcoming = false
                },

                // ── COMING SOON ──────────────────────────────────────────

                new Movie
                {
                    Id = 9,
                    Title = "The Shawshank Redemption",
                    Genre = "Drama",
                    DurationMinutes = 142,
                    AgeRating = "15+",
                    Description = "FEAR CAN HOLD YOU PRISONER. HOPE CAN SET YOU FREE." + Environment.NewLine +
                                  "Imprisoned in the 1940s for the double murder of his wife and her lover, upstanding banker Andy Dufresne begins a new life at the Shawshank prison, where he puts his accounting skills to work for an amoral warden. During his long stretch in prison, Dufresne comes to be admired by the other inmates — including an older prisoner named Red — for his integrity and unquenchable sense of hope.",
                    Director = "Frank Darabont",
                    ImagePath = "/images/TheShawshankRedemption.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/NmzuHjWmXOc",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 10,
                    Title = "Schindler's List",
                    Genre = "Drama / History",
                    DurationMinutes = 195,
                    AgeRating = "15+",
                    Description = "WHOEVER SAVES ONE LIFE, SAVES THE WORLD ENTIRE." + Environment.NewLine +
                                  "The true story of how businessman Oskar Schindler saved over a thousand Jewish lives from the Nazis while they worked as slaves in his factory during World War II.",
                    Director = "Steven Spielberg",
                    ImagePath = "/images/Schindler’sList.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/mxphAlJID9U",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 11,
                    Title = "Fight Club",
                    Genre = "Drama / Thriller",
                    DurationMinutes = 139,
                    AgeRating = "18+",
                    Description = "MISCHIEF. MAYHEM. SOAP." + Environment.NewLine +
                                  "A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground fight clubs forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.",
                    Director = "David Fincher",
                    ImagePath = "/images/FightClub.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/SUXWAEX2jlg",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 12,
                    Title = "Interstellar",
                    Genre = "Sci-Fi / Adventure",
                    DurationMinutes = 169,
                    AgeRating = "12+",
                    Description = "MANKIND WAS BORN ON EARTH. IT WAS NEVER MEANT TO DIE HERE." + Environment.NewLine +
                                  "The adventures of a group of explorers who make use of a newly discovered wormhole to surpass the limitations on human space travel and conquer the vast distances involved in an interstellar voyage.",
                    Director = "Christopher Nolan",
                    ImagePath = "/images/Interstellar.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/zSWdZVtXT7E",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 13,
                    Title = "The Silence of the Lambs",
                    Genre = "Crime / Thriller",
                    DurationMinutes = 118,
                    AgeRating = "18+",
                    Description = "TO ENTER THE MIND OF A KILLER SHE MUST CHALLENGE THE MIND OF A MADMAN." + Environment.NewLine +
                                  "Clarice Starling is a top student at the FBI's training academy. Jack Crawford wants Clarice to interview Dr. Hannibal Lecter, a brilliant psychiatrist who is also a violent psychopath, serving life behind bars for various acts of murder and cannibalism. Crawford believes that Lecter may have insight into a case and that Starling, as an attractive young woman, may be just the bait to draw him out.",
                    Director = "Jonathan Demme",
                    ImagePath = "/images/TheSilenceoftheLambs.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/W6Mm8Sbe__o",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 14,
                    Title = "1917",
                    Genre = "War / Drama",
                    DurationMinutes = 119,
                    AgeRating = "15+",
                    Description = "TIME IS THE ENEMY." + Environment.NewLine +
                                  "At the height of the First World War, two young British soldiers must cross enemy territory and deliver a message that will stop a deadly attack on hundreds of soldiers.",
                    Director = "Sam Mendes",
                    ImagePath = "/images/1917.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/YqNYrYUiMfg",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 15,
                    Title = "Saving Private Ryan",
                    Genre = "War / Drama",
                    DurationMinutes = 169,
                    AgeRating = "15+",
                    Description = "THE MISSION IS A MAN." + Environment.NewLine +
                                  "As U.S. troops storm the beaches of Normandy, three brothers lie dead on the battlefield, with a fourth trapped behind enemy lines. Ranger captain John Miller and seven men are tasked with penetrating German-held territory and bringing the boy home.",
                    Director = "Steven Spielberg",
                    ImagePath = "/images/SavingPrivateRyan.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/zwhP5b4tD6g",
                    IsUpcoming = true
                },
                new Movie
                {
                    Id = 16,
                    Title = "Judgment at Nuremberg",
                    Genre = "Drama / History",
                    DurationMinutes = 186,
                    AgeRating = "15+",
                    Description = "THE EVENT THE WORLD WILL NEVER FORGET." + Environment.NewLine +
                                  "In 1947, four German judges who served on the bench during the Nazi regime face a military tribunal to answer charges of crimes against humanity. Chief Justice Haywood hears evidence and testimony not only from lead defendant Ernst Janning and his defense attorney Hans Rolfe, but also from the widow of a Nazi general, an idealistic U.S. Army captain and reluctant witness Irene Wallner.",
                    Director = "Stanley Kramer",
                    ImagePath = "/images/JudgmentatNuremberg.jpg",
                    TrailerUrl = "https://www.youtube.com/embed/T3taV43-lGc",
                    IsUpcoming = true
                }
            );
        }
    }
}