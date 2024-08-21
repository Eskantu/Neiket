using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeitekWS.Models;

namespace NeitekWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetasController : ControllerBase
    {
        private readonly NeitekContext _context;

        public MetasController(NeitekContext context)
        {
            _context = context;
        }

        // GET: api/Metas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meta>>> GetMetas()
        {
            return await _context.Metas.ToListAsync();
        }

        // GET: api/Metas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meta>> GetMeta(int id)
        {
            var meta = await _context.Metas.FindAsync(id);

            if (meta == null)
            {
                return NotFound();
            }

            return meta;
        }

        // PUT: api/Metas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeta(int id, Meta meta)
        {
            if (id != meta.PkMeta)
            {
                return BadRequest();
            }

            _context.Entry(meta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaExists(id))
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

        // POST: api/Metas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meta>> PostMeta(Meta meta)
        {
            _context.Metas.Add(meta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeta", new { id = meta.PkMeta }, meta);
        }

        // DELETE: api/Metas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeta(int id)
        {
            var meta = await _context.Metas.FindAsync(id);
            if (meta == null)
            {
                return NotFound();
            }

            _context.Metas.Remove(meta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetaExists(int id)
        {
            return _context.Metas.Any(e => e.PkMeta == id);
        }
    }
}
