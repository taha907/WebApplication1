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
                    Title = "kuru otlar �st�ne",
                    Description = "G�zel filmdir",
                    Director = "nuri bilge ceylan",
                    Players = new string[] { "taha", "alper" },
                    ImageUrl = "kuru_Otlar.jpg",
                    GenreId = 4


                },
                new Movie
                {
                    MovieId = 2,
                    Title = "uzak",
                    Description = "G�zel birrrrrrrr filmdir",
                    Director = "nuri bilge ceylan",
                    Players = new string[] { "taha", "alper" },
                    ImageUrl = "Uzak_afi�.jpg",
                    GenreId = 4
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "gibi",
                    Description = "�ok g�zel bir filmmm",
                    Director = "Y�lmazzzzzzz",
                    Players = new string[] { "y�lmaz", "ilkkan" },
                    ImageUrl = "Gibi_afi�.jpg",
                    GenreId = 2
                },
                new Movie
                {
                    MovieId = 4,
                    Title = "gibi 65437347",
                    Description = "�ok g�zel bir filmmm",
                    Director = "Y�lmazzzzzzz",
                    Players = new string[] { "y�lmaz", "ilkkan" },
                    ImageUrl = "Gibi_afi�.jpg",
                    GenreId = 2
                },
                new Movie
                {
                    MovieId = 5,
                    Title = "gibi 5363645",
                    Description = "�ok g�zel bir filmmm",
                    Director = "Y�lmazzzzzzz",
                    Players = new string[] { "y�lmaz", "ilkkan" },
                    ImageUrl = "Gibi_afi�.jpg",
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
            //listedeki her eleman� d�ng� ile d�n ve MovieIdlerine ula��p
            //s�ras�yla id parametesine e�it olursa Listedeki o m de�erini d�nder
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
