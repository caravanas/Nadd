using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Avaliacoes
{
    public class EditModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public EditModel(Nadd.Models.NaddContext context)
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
           ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Nome");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Avaliacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvaliacaoExists(Avaliacao.Id))
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

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacao.Any(e => e.Id == id);
        }
    }
}
