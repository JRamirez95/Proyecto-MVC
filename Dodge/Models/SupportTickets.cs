using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dodge.Models
{
    public class SupportTickets
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Subject")]
        public string subject { get; set; }

        [Required]
        [Display(Name = "Problem")]
        public string problem { get; set; }

        [Required]
        [Display(Name = "Who Reported")]
        public string who { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [Required]
        [Display(Name = "State")]
        public string state { get; set; }
    }
}
