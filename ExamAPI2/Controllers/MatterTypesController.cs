using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamAPI2.Models;

namespace ExamAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MatterTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MatterTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatterType>>> GetmatterTypes()
        {
            return await _context.matterTypes.ToListAsync();
        }

        // GET: api/MatterTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatterType>> GetMatterType(int id)
        {
            var matterType = await _context.matterTypes.FindAsync(id);

            if (matterType == null)
            {
                return NotFound();
            }

            return matterType;
        }

        // PUT: api/MatterTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatterType(int id, MatterType matterType)
        {
            if (id != matterType.Id)
            {
                return BadRequest();
            }

            _context.Entry(matterType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatterTypeExists(id))
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

        // POST: api/MatterTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MatterType>> PostMatterType(MatterType matterType)
        {
            _context.matterTypes.Add(matterType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatterType", new { id = matterType.Id }, matterType);
        }

        // DELETE: api/MatterTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatterType>> DeleteMatterType(int id)
        {
            var matterType = await _context.matterTypes.FindAsync(id);
            if (matterType == null)
            {
                return NotFound();
            }

            _context.matterTypes.Remove(matterType);
            await _context.SaveChangesAsync();

            return matterType;
        }

        private bool MatterTypeExists(int id)
        {
            return _context.matterTypes.Any(e => e.Id == id);
        }
    }
}
