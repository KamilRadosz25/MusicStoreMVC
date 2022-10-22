using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var genreModel = _dbContext.Genres.Include("Albums")
            .Single(g => g.Name == genre);

            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = _dbContext.Albums.Find(id);

            return View(album);   
        }

    }
}
