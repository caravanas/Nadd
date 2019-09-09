using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Pages.Avaliacoes
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
        ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Avaliacao Avaliacao { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Avaliacao.Add(Avaliacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}