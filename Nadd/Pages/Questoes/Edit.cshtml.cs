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

namespace Nadd.Pages.Questoes
{
    public class EditModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public EditModel(Nadd.Models.NaddContext context)
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
           ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Questao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestaoExists(Questao.Id))
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

        private bool QuestaoExists(int id)
        {
            return _context.Questao.Any(e => e.Id == id);
        }
    }
}
