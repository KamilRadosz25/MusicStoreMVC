using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.Models;
using System.Web;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly MusicStoreEntities _dbContext;

        public StoreController(MusicStoreEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var genres = _dbContext.Genres.ToList();
            return View(genres);
        }
        public ActionResult Browse(string genre)
        {
            var genreModel = new Genre { Name = genre };

            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = new Album{ Title = "Album " + id };

            return View(album);   
        }

    }
}
