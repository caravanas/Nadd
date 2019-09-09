using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Avaliacoes
{
    public class DetailsModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public DetailsModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public Avaliacao Avaliacao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Avaliacao = await _context.Avaliacao
                .Include(a => a.Disciplina).FirstOrDefaultAsync(m => m.Id == id);

            if (Avaliacao == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
