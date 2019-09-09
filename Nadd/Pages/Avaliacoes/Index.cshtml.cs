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
    public class IndexModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public IndexModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public IList<Avaliacao> Avaliacao { get;set; }

        public async Task OnGetAsync()
        {
            Avaliacao = await _context.Avaliacao
                .Include(a => a.Disciplina).ToListAsync();
        }
    }
}
