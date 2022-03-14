using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_API.Models;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblempsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public TblempsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Tblemps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblemp>>> GetTblemps()
        {
            return await _context.Tblemps.ToListAsync();
        }

        // GET: api/Tblemps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblemp>> GetTblemp(int id)
        {
            var tblemp = await _context.Tblemps.FindAsync(id);

            if (tblemp == null)
            {
                return NotFound();
            }

            return tblemp;
        }

        // PUT: api/Tblemps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblemp(int id, Tblemp tblemp)
        {
            if (id != tblemp.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblemp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblempExists(id))
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

        // POST: api/Tblemps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tblemp>> PostTblemp(Tblemp tblemp)
        {
            _context.Tblemps.Add(tblemp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblemp", new { id = tblemp.Id }, tblemp);
        }

        // DELETE: api/Tblemps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblemp(int id)
        {
            var tblemp = await _context.Tblemps.FindAsync(id);
            if (tblemp == null)
            {
                return NotFound();
            }

            _context.Tblemps.Remove(tblemp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblempExists(int id)
        {
            return _context.Tblemps.Any(e => e.Id == id);
        }
    }
}
