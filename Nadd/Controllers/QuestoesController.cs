using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nadd.Model;
using Nadd.Models;

namespace Nadd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestoesController : ControllerBase
    {
        private readonly NaddContext _context;

        public QuestoesController(NaddContext context)
        {
            _context = context;
        }

        // GET: api/Questoes
        [HttpGet]
        public IEnumerable<Questao> GetQuestao()
        {
            return _context.Questao;
        }

        // GET: api/Questoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questao = await _context.Questao.FindAsync(id);

            if (questao == null)
            {
                return NotFound();
            }

            return Ok(questao);
        }

        // PUT: api/Questoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestao([FromRoute] int id, [FromBody] Questao questao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questao.Id)
            {
                return BadRequest();
            }

            _context.Entry(questao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questoes
        [HttpPost]
        public async Task<IActionResult> PostQuestao([FromBody] Questao questao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Questao.Add(questao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestao", new { id = questao.Id }, questao);
        }

        // DELETE: api/Questoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestao([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questao = await _context.Questao.FindAsync(id);
            if (questao == null)
            {
                return NotFound();
            }

            _context.Questao.Remove(questao);
            await _context.SaveChangesAsync();

            return Ok(questao);
        }

        private bool QuestaoExists(int id)
        {
            return _context.Questao.Any(e => e.Id == id);
        }
    }
}