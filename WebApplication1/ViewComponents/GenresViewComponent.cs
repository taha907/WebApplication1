using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        //tasarlanan viewcomponent tetiklendi�inde yani render edildi�inde �al��mas�n�
        //istedi�imiz kodlar� IViewComponent imzal� metot i�ine yazar�z
        // bu s�n�f componentin kendi controller� gibi d���n�lebilir DB i�lemleri de yapabilir.
        public IViewComponentResult Invoke()
        {
            //RouteData ile aktif url deki hangi b�l�m istersek {Controller}/{Action}/{id} alabiliriz. 
            //se�ili t�r�n idsini viewBag kullanarak Ba�l� Viewden bu veriye ula�abiliriz
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(GenreRepository.Genres);
        }
    }
}
