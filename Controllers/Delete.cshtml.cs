using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICETASKONE.Data;
using ICETASKONE.Models;

namespace ICETASKONE.Controllers
{
    public class DeleteModel : PageModel
    {
        private readonly ICETASKONE.Data.ICETASKONEContext _context;

        public DeleteModel(ICETASKONE.Data.ICETASKONEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RapMusic RapMusic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapmusic = await _context.RapMusic.FirstOrDefaultAsync(m => m.Id == id);

            if (rapmusic == null)
            {
                return NotFound();
            }
            else
            {
                RapMusic = rapmusic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rapmusic = await _context.RapMusic.FindAsync(id);
            if (rapmusic != null)
            {
                RapMusic = rapmusic;
                _context.RapMusic.Remove(RapMusic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
