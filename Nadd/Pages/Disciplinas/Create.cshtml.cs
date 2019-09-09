using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Disciplinas
{
    public class CreateModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public CreateModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CursoID"] = new SelectList(_context.Curso, "Id", "Nome");
        ViewData["ProfessorID"] = new SelectList(_context.Professor, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Disciplina Disciplina { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Disciplina.Add(Disciplina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}