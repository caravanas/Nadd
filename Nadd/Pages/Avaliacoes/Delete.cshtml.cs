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
    public class DeleteModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public DeleteModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Avaliacao = await _context.Avaliacao.FindAsync(id);

            if (Avaliacao != null)
            {
                _context.Avaliacao.Remove(Avaliacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
