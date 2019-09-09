using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Disciplinas
{
    public class DetailsModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public DetailsModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public Disciplina Disciplina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Disciplina = await _context.Disciplina
                .Include(d => d.Curso)
                .Include(d => d.Professor).FirstOrDefaultAsync(m => m.Id == id);

            if (Disciplina == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
