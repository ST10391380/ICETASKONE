using ICETASKONE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICETASKONE.Controllers
{
    public class RapMusicController : Controller
    {
        private List<RapMusic> _songs; // List to store rap song data

        public RapMusicController()
        {
            // In a real application, data would come from a database or external source.
            // For simplicity, we'll create a sample list here.
            _songs = new List<RapMusic>()
        {
            new RapMusic { Id = 1, Artist = "Pranav.wav", Title = "JFK", Genre = "Trap Metal", ReleaseYear = 2023, Keywords = new List<string>() { "classic", "lyrical" } },
            new RapMusic { Id = 2, Artist = "Playboi Carti", Title = "M3tamorphisis", Genre = "Rage", ReleaseYear = 2020, Keywords = new List<string>() { "social commentary", "empowering" } },
            new RapMusic { Id = 3, Artist = "Earl Sweatshirt", Title = "The Mint", Genre = "Abstract Hip-Hop", ReleaseYear = 2018, Keywords = new List<string>() { "party", "fun" } },
        };

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Recommend(string keyword)
        {
            // Filter songs based on the provided keyword
            var recommendedSongs = _songs.Where(s => s.Keywords.Contains(keyword)).ToList();
            return View(recommendedSongs);
        }
    }
}
