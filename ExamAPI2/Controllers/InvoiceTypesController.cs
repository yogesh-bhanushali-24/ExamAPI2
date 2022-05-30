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
    public class InvoiceTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoiceTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceType>>> GetinvoiceTypes()
        {
            return await _context.invoiceTypes.ToListAsync();
        }

        // GET: api/InvoiceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceType>> GetInvoiceType(int id)
        {
            var invoiceType = await _context.invoiceTypes.FindAsync(id);

            if (invoiceType == null)
            {
                return NotFound();
            }

            return invoiceType;
        }

        // PUT: api/InvoiceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceType(int id, InvoiceType invoiceType)
        {
            if (id != invoiceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTypeExists(id))
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

        // POST: api/InvoiceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvoiceType>> PostInvoiceType(InvoiceType invoiceType)
        {
            _context.invoiceTypes.Add(invoiceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceType", new { id = invoiceType.Id }, invoiceType);
        }

        // DELETE: api/InvoiceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceType>> DeleteInvoiceType(int id)
        {
            var invoiceType = await _context.invoiceTypes.FindAsync(id);
            if (invoiceType == null)
            {
                return NotFound();
            }

            _context.invoiceTypes.Remove(invoiceType);
            await _context.SaveChangesAsync();

            return invoiceType;
        }

        private bool InvoiceTypeExists(int id)
        {
            return _context.invoiceTypes.Any(e => e.Id == id);
        }
    }
}
