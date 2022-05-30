using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAPI2.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string ClientName { get; set; }

    }
}
