using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>() {
                new Genre{GenreId = 1, Name = "Macera"},
                new Genre{GenreId = 2, Name = "Komedi"},
                new Genre{GenreId = 3, Name = "Romantik"}, 
                new Genre{GenreId = 4, Name = "Dram"}
            };
        }
        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }

        /* burda metot olarak da Get yap�labilir 
         ama performans fark� a��s�ndan propert (�stteki daha h�zl�) ve ufak farklar� da var yap�sal olarak
        public static List<Genre> Genres()
        {
            return _genres;
        }
        */

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre getById(int id)
        {
            return _genres.FirstOrDefault(m => m.GenreId == id);
        }


    }
}
