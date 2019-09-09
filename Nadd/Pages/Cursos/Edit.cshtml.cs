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

namespace Nadd.Pages.Cursos
{
    public class EditModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public EditModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AreaID"] = new SelectList(_context.Area, "ID", "Nome");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(Curso.Id))
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

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
