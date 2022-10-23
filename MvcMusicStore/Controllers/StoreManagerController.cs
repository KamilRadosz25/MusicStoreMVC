using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private readonly MusicStoreEntities _context;

        public StoreManagerController(MusicStoreEntities context)
        {
            _context = context;
        }

        // GET: StoreManager
        public async Task<IActionResult> Index()
        {
            var musicStoreEntities = _context.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(await musicStoreEntities.ToListAsync());
        }

        // GET: StoreManager/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = _context.Albums.Find(id);
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(album).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = _context.Albums.Find(id);
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = _context.Albums.Find(id);
            _context.Albums.Remove(album);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
