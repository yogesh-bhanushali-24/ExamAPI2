using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPI2.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }

        public DbSet<CompanyDetails> companies { get; set; }
        public DbSet<BillingTerm> BillingTerms { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<InvoiceType> invoiceTypes { get; set; }

        public DbSet<MatterType> matterTypes { get; set; }
    }
}
