using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        //tasarlanan viewcomponent tetiklendiðinde yani render edildiðinde çalýþmasýný
        //istediðimiz kodlarý IViewComponent imzalý metot içine yazarýz
        // bu sýnýf componentin kendi controllerý gibi düþünülebilir DB iþlemleri de yapabilir.
        public IViewComponentResult Invoke()
        {
            //RouteData ile aktif url deki hangi bölüm istersek {Controller}/{Action}/{id} alabiliriz. 
            //seçili türün idsini viewBag kullanarak Baðlý Viewden bu veriye ulaþabiliriz
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(GenreRepository.Genres);
        }
    }
}
