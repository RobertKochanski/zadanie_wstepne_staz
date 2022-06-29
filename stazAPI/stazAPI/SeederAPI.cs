using stazDAL;
using stazDAL.Entities;

namespace stazAPI
{
    public class SeederAPI
    {
        private readonly StazDbContext _context;

        public SeederAPI(StazDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.authors.Any())
                {
                    var authors = GetAuthors();
                    _context.authors.AddRange(authors);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Author> GetAuthors()
        {
            var data = new List<Author>()
            {
                new Author()
                {
                    FirstName = "Adam",
                    SurName = "Mickiewicz",
                    Books = new List<Book>()
                    {
                       new Book()
                       {
                           Title = "Dziady część I",
                           Description = "Mickiewicz rozpoczął pisanie tej części najprawdopodobniej w 1821 roku, jednakże nigdy jej nie ukończył. Po raz pierwszy, Dziady cz. I trafiły do druku w 1860 w Paryżu, wchodząc w skład pośmiertnego wydania najważniejszych dzieł artysty;",
                           Release_Date = new DateTime(1822, 1, 1)
                       },

                       new Book()
                       {
                           Title = "Pan Tadeusz",
                           Description = "Epopeja napisana w Paryżu w latach 1832–1834, wydana w 1834 roku. W Panu Tadeuszu Mickiewicz przedstawił romantyczną i pełną nostalgii wizję Polski szlacheckiej;",
                           Release_Date = new DateTime(1834, 6, 28)
                       }
                    }
                },

                new Author()
                {
                    FirstName = "Henryk",
                    SurName = "Sienkiewicz",
                    Books = new List<Book>()
                    {
                       new Book()
                       {
                           Title = "Potop",
                           Description = "Druga z powieści tworzących Trylogię Henryka Sienkiewicza wydana w 1886 roku (pozostałe części to Ogniem i mieczem i Pan Wołodyjowski), opowiadająca o potopie szwedzkim z lat 1655–1660.",
                           Release_Date = new DateTime(1886, 1, 1)
                       },

                       new Book()
                       {
                           Title = "Krzyżacy",
                           Description = "Powieść historyczna Henryka Sienkiewicza publikowana w latach 1897–1900 w „Tygodniku Illustrowanym”, wydana w 1900 w Warszawie przez wydawnictwo „Gebethner i Wolff” (wydanie jubileuszowe); rękopis powieści przechowuje Biblioteka Narodowa (sygn. IV 6068)",
                           Release_Date = new DateTime(1900, 1, 1)
                       }
                    }
                }
            };

            return data;
        }
    }
}
