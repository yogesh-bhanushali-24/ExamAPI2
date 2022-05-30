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
    public class BillingTermsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillingTermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillingTerms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillingTerm>>> GetBillingTerms()
        {
            return await _context.BillingTerms.ToListAsync();
        }

        // GET: api/BillingTerms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillingTerm>> GetBillingTerm(int id)
        {
            var billingTerm = await _context.BillingTerms.FindAsync(id);

            if (billingTerm == null)
            {
                return NotFound();
            }

            return billingTerm;
        }

        // PUT: api/BillingTerms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillingTerm(int id, BillingTerm billingTerm)
        {
            if (id != billingTerm.Id)
            {
                return BadRequest();
            }

            _context.Entry(billingTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingTermExists(id))
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

        // POST: api/BillingTerms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillingTerm>> PostBillingTerm(BillingTerm billingTerm)
        {
            _context.BillingTerms.Add(billingTerm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillingTerm", new { id = billingTerm.Id }, billingTerm);
        }

        // DELETE: api/BillingTerms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillingTerm>> DeleteBillingTerm(int id)
        {
            var billingTerm = await _context.BillingTerms.FindAsync(id);
            if (billingTerm == null)
            {
                return NotFound();
            }

            _context.BillingTerms.Remove(billingTerm);
            await _context.SaveChangesAsync();

            return billingTerm;
        }

        private bool BillingTermExists(int id)
        {
            return _context.BillingTerms.Any(e => e.Id == id);
        }
    }
}
