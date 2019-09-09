using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Areas
{
    public class CreateModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public CreateModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Area Area { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Area.Add(Area);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}