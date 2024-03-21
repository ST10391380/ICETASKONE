using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ICETASKONE.Data;
using ICETASKONE.Models;

namespace ICETASKONE.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly ICETASKONE.Data.ICETASKONEContext _context;

        public CreateModel(ICETASKONE.Data.ICETASKONEContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RapMusic RapMusic { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RapMusic.Add(RapMusic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
