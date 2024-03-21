using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICETASKONE.Data;
using ICETASKONE.Models;

namespace ICETASKONE.Controllers
{
    public class EditModel : PageModel
    {
        private readonly ICETASKONE.Data.ICETASKONEContext _context;

        public EditModel(ICETASKONE.Data.ICETASKONEContext context)
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

            var rapmusic =  await _context.RapMusic.FirstOrDefaultAsync(m => m.Id == id);
            if (rapmusic == null)
            {
                return NotFound();
            }
            RapMusic = rapmusic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RapMusic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RapMusicExists(RapMusic.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RapMusicExists(int id)
        {
            return _context.RapMusic.Any(e => e.Id == id);
        }
    }
}
