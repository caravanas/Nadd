using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Questoes
{
    public class DetailsModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public DetailsModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public Questao Questao { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Questao = await _context.Questao
                .Include(q => q.Avaliacao).FirstOrDefaultAsync(m => m.Id == id);

            if (Questao == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
