using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICETASKONE.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICETASKONE.Data.ICETASKONEContext _context;

        public IndexModel(ICETASKONE.Data.ICETASKONEContext context)
        {
            _context = context;
        }
        
        public void OnGet()
        {

        }
    }
}
