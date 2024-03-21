using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICETASKONE.Data;
using ICETASKONE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICETASKONE.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly ICETASKONE.Data.ICETASKONEContext _context;

        public IndexModel(ICETASKONE.Data.ICETASKONEContext context)
        {
            _context = context;
        }

        public IList<RapMusic> RapMusic { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SongGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.RapMusic
                                            orderby m.Genre
                                            select m.Genre;

            var songs = from m in _context.RapMusic
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SongGenre))
            {
                songs = songs.Where(x => x.Genre == SongGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            RapMusic = await _context.RapMusic.ToListAsync();
            
        }
    }
}
