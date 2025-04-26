using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie
                {   MovieId = 1,
                    Title = "kuru otlar üstüne",
                    Description = "Güzel filmdir",
                    Director = "nuri bilge ceylan",
                    Players = new string[] { "taha", "alper" },
                    ImageUrl = "kuru_Otlar.jpg",
                    GenreId = 4


                },
                new Movie
                {
                    MovieId = 2,
                    Title = "uzak",
                    Description = "Güzel birrrrrrrr filmdir",
                    Director = "nuri bilge ceylan",
                    Players = new string[] { "taha", "alper" },
                    ImageUrl = "Uzak_afiþ.jpg",
                    GenreId = 4
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "gibi",
                    Description = "çok güzel bir filmmm",
                    Director = "Yýlmazzzzzzz",
                    Players = new string[] { "yýlmaz", "ilkkan" },
                    ImageUrl = "Gibi_afiþ.jpg",
                    GenreId = 2
                },
                new Movie
                {
                    MovieId = 4,
                    Title = "gibi 65437347",
                    Description = "çok güzel bir filmmm",
                    Director = "Yýlmazzzzzzz",
                    Players = new string[] { "yýlmaz", "ilkkan" },
                    ImageUrl = "Gibi_afiþ.jpg",
                    GenreId = 2
                },
                new Movie
                {
                    MovieId = 5,
                    Title = "gibi 5363645",
                    Description = "çok güzel bir filmmm",
                    Director = "Yýlmazzzzzzz",
                    Players = new string[] { "yýlmaz", "ilkkan" },
                    ImageUrl = "Gibi_afiþ.jpg",
                    GenreId = 2 

                }
            };
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }
        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Count() + 1;
            _movies.Add(movie); 
        }

        public static Movie getById(int id)
        {
            //listedeki her elemaný döngü ile dön ve MovieIdlerine ulaþýp
            //sýrasýyla id parametesine eþit olursa Listedeki o m deðerini dönder
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }
        public static void Edit(Movie m)
        {
            foreach(var item in _movies)
            {
                if(item.MovieId == m.MovieId)
                {
                    item.Title = m.Title;
                    item.Director = m.Director;
                    item.Description = m.Description;
                    item.GenreId = m.GenreId;
                    item.ImageUrl = m.ImageUrl;
                    break;

                }
            }
        }
    }
}
