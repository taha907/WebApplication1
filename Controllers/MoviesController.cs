using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{   //controller nasýl çalýþýr?
    //Controller adý "Movie" olduðu için varsayýlan olarak Views/Movie/Details.cshtml aranýr.
    public class MoviesController : Controller
    {   //action
        //localhost:17724/movies/list
    
        //localhost:17724/movies/list/id
        public IActionResult List(int? id,string q)
            //burda q parametresi String-> referans tipli olduðu için zaten null olabilir.
            //bu yüzden ? kullanmaya gerek yok

        {
            // gelen isteði parametre harici böylede alabiliriz.
            // var kelime = HttpContext.Request.Query["q"].ToString();
            var kelime = q;
            
            var movies = MovieRepository.Movies;

            //eðer bir id ile filtreleme yapýlýyorsa null dönmez if e girer
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
                //filtrelenmiþ veya filtrelenmemiþ filmleri model aracýlýðýyle view e döndürecek model deðiþkenine atanýr
                Movie = movies

            };

            //buradaki View metodu ile hangi Viewe hangi verileri göndereceksek yolluyoruz (model þeklinde)
            return View("Movies",model);
        }

        //localhost:5000/movies/details/id
        public IActionResult Details(int id)
        {
            //view'e veri gönderiyor
            return View(MovieRepository.getById(id));
        }



        [HttpGet] //actionlarýn default deðeridir
        public IActionResult Create()
        {
            //form ilk açýldýðýnda bu metot çalýþýr. submit butonuna basýldýðý an parametreler atanýr ve o an
            //aþaðýdaki parametreli create metodu çalýþýr
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Description, string Director, string ImageUrl,int GenreId)
        {
            // Model Binding ->> ilgili formun body kýsmýndan verileri alarak ilgili actiona parametre olarak atar
            var model = new Movie
            {
                Title = Title,
                Description = Description,
                Director = Director,
                ImageUrl = ImageUrl,
                GenreId =  GenreId
            };

            MovieRepository.Add(model);
            
            //RedirectToAction -> benim bnu actionda iþim bitti, List actionundan devam et :) ->>
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)

        /* bu metodun 2 http çeþidi var,  1 -> GET    2 -> POST
         * Get ile güncellenmek istenen filmin bilgilerini forma yansýtmayý,
         * Post ile yansýtýldýktan sonra deðiþtirilmek sitenen özellikleri girdikten sonra güncelleme iþlemini yapmayý saðlarýz
        ilgili filmin update butonuna basýldýðýnda urlnin id kýsmýný burda Edit actionu bekliyor.
        modelle veriyi gönderdik
       */
        {
            return View(MovieRepository.getById(id));
        }


        
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            /* ASP.NET, formdaki input'lardan gelen verileri Movie sýnýfýnýn uyumlu property'lerine otomatik olarak eþleþtirir (bind eder).
             bu yüzden parametre olarak bir türden(Movie sýnýfý) bir nesne(m nesnesi) verebiliriz.
            O türe baðlý her property parametre olarak formda verilmek zorunda deðildir
            Yani NULL deðer alabilen propertyler, nesne parametre olarak metoda verildiðinde
            model binding aracýlýðýyla otomatik deðerler atanýr */

            MovieRepository.Edit(m);

            return RedirectToAction("Movies","List",new {@id=m.MovieId});
        }




    }
}
