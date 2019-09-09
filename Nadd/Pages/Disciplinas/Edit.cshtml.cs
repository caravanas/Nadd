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

namespace Nadd.Pages.Disciplinas
{
    public class EditModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public EditModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CursoID"] = new SelectList(_context.Curso, "Id", "Nome");
           ViewData["ProfessorID"] = new SelectList(_context.Professor, "Id", "Nome");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Disciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(Disciplina.Id))
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

        private bool DisciplinaExists(int id)
        {
            return _context.Disciplina.Any(e => e.Id == id);
        }
    }
}
