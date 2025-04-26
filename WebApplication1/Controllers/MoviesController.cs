using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{   //controller nas�l �al���r?
    //Controller ad� "Movie" oldu�u i�in varsay�lan olarak Views/Movie/Details.cshtml aran�r.
    public class MoviesController : Controller
    {   //action
        //localhost:17724/movies/list
    
        //localhost:17724/movies/list/id
        public IActionResult List(int? id,string q)
            //burda q parametresi String-> referans tipli oldu�u i�in zaten null olabilir.
            //bu y�zden ? kullanmaya gerek yok

        {
            // gelen iste�i parametre harici b�ylede alabiliriz.
            // var kelime = HttpContext.Request.Query["q"].ToString();
            var kelime = q;
            
            var movies = MovieRepository.Movies;

            //e�er bir id ile filtreleme yap�l�yorsa null d�nmez if e girer
            if(id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i=>
                i.Title.ToLower().Contains(q.ToLower()) || 
                i.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MovieViewModel()
            {
                //filtrelenmi� veya filtrelenmemi� filmleri model arac�l���yle view e d�nd�recek model de�i�kenine atan�r
                Movie = movies

            };

            //buradaki View metodu ile hangi Viewe hangi verileri g�ndereceksek yolluyoruz (model �eklinde)
            return View("Movies",model);
        }

        //localhost:5000/movies/details/id
        public IActionResult Details(int id)
        {
            //view'e veri g�nderiyor
            return View(MovieRepository.getById(id));
        }



        [HttpGet] //actionlar�n default de�eridir
        public IActionResult Create()
        {
            //form ilk a��ld���nda bu metot �al���r. submit butonuna bas�ld��� an parametreler atan�r ve o an
            //a�a��daki parametreli create metodu �al���r
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Description, string Director, string ImageUrl,int GenreId)
        {
            // Model Binding ->> ilgili formun body k�sm�ndan verileri alarak ilgili actiona parametre olarak atar
            var model = new Movie
            {
                Title = Title,
                Description = Description,
                Director = Director,
                ImageUrl = ImageUrl,
                GenreId =  GenreId
            };

            MovieRepository.Add(model);
            
            //RedirectToAction -> benim bnu actionda i�im bitti, List actionundan devam et :) ->>
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)

        /* bu metodun 2 http �e�idi var,  1 -> GET    2 -> POST
         * Get ile g�ncellenmek istenen filmin bilgilerini forma yans�tmay�,
         * Post ile yans�t�ld�ktan sonra de�i�tirilmek sitenen �zellikleri girdikten sonra g�ncelleme i�lemini yapmay� sa�lar�z
        ilgili filmin update butonuna bas�ld���nda urlnin id k�sm�n� burda Edit actionu bekliyor.
        modelle veriyi g�nderdik
       */
        {
            return View(MovieRepository.getById(id));
        }


        
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            /* ASP.NET, formdaki input'lardan gelen verileri Movie s�n�f�n�n uyumlu property'lerine otomatik olarak e�le�tirir (bind eder).
             bu y�zden parametre olarak bir t�rden(Movie s�n�f�) bir nesne(m nesnesi) verebiliriz.
            O t�re ba�l� her property parametre olarak formda verilmek zorunda de�ildir
            Yani NULL de�er alabilen propertyler, nesne parametre olarak metoda verildi�inde
            model binding arac�l���yla otomatik de�erler atan�r */

            MovieRepository.Edit(m);

            return RedirectToAction("Movies","List",new {@id=m.MovieId});
        }




    }
}
