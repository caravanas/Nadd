using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Cursos
{
    public class DetailsModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public DetailsModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public Curso Curso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curso = await _context.Curso
                .Include(c => c.Area).FirstOrDefaultAsync(m => m.Id == id);

            if (Curso == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
