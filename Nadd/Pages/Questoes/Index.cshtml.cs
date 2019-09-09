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
    public class IndexModel : PageModel
    {
        private readonly Nadd.Models.NaddContext _context;

        public IndexModel(Nadd.Models.NaddContext context)
        {
            _context = context;
        }

        public IList<Questao> Questao { get;set; }

        public async Task OnGetAsync()
        {
            Questao = await _context.Questao
                .Include(q => q.Avaliacao).ToListAsync();
        }
    }
}
