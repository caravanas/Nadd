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
    public class DeleteModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public DeleteModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Questao = await _context.Questao.FindAsync(id);

            if (Questao != null)
            {
                _context.Questao.Remove(Questao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
