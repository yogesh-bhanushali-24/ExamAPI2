using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPI2.Models
{
    public class CompanyDetails
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        [NotMapped]
        public string ClientName { get; set; }

        public string ProjectName { get; set; }

        public int MatterTypeId { get; set; }
        [NotMapped]
        public string MatterTypeName { get; set; }


        public int BillingTermsId { get; set; }
        [NotMapped]
        public string BillingTermsName { get; set; }

        public int InvoiceTypeId { get; set; }
        [NotMapped]
        public string InvoiceTypeName { get; set; }

        public string Description { get; set; }
        public int Invoiceable { get; set; }
    }
}
