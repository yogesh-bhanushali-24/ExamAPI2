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
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDetails>>> Getcompanies()
        {
            var result = (from c in _context.companies
                         join h in _context.BillingTerms on c.BillingTermsId equals h.Id
                         join cl in _context.clients on c.ClientId equals cl.Id
                         join i in _context.invoiceTypes on c.InvoiceTypeId equals i.Id
                         join m in _context.matterTypes on c.MatterTypeId equals m.Id
                         select new CompanyDetails
                         {
                             Id = c.Id,
                             ClientId = c.ClientId,
                             ClientName = cl.ClientName,
                             ProjectName = c.ProjectName,
                             MatterTypeId = c.MatterTypeId,
                             MatterTypeName = m.MatterTypeName,
                             BillingTermsId = c.BillingTermsId,
                             BillingTermsName=h.BillingTermsName,
                             InvoiceTypeId=c.InvoiceTypeId,
                             InvoiceTypeName=i.InvoiceTypeName,
                             Description = c.Description,
                             Invoiceable = c.Invoiceable
                         }).ToListAsync();

            return await result;
        }

        // GET: api/CompanyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetails>> GetCompanyDetails(int id)
        {
            var companyDetails = await _context.companies.FindAsync(id);

            if (companyDetails == null)
            {
                return NotFound();
            }

            return companyDetails;
        }

        // PUT: api/CompanyDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyDetails(int id, CompanyDetails companyDetails)
        {
            if (id != companyDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDetailsExists(id))
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

        // POST: api/CompanyDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CompanyDetails>> PostCompanyDetails(CompanyDetails companyDetails)
        {
            _context.companies.Add(companyDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyDetails", new { id = companyDetails.Id }, companyDetails);
        }

        // DELETE: api/CompanyDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyDetails>> DeleteCompanyDetails(int id)
        {
            var companyDetails = await _context.companies.FindAsync(id);
            if (companyDetails == null)
            {
                return NotFound();
            }

            _context.companies.Remove(companyDetails);
            await _context.SaveChangesAsync();

            return companyDetails;
        }

        private bool CompanyDetailsExists(int id)
        {
            return _context.companies.Any(e => e.Id == id);
        }
    }
}
