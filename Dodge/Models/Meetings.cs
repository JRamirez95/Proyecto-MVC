using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Dodge.Models
{
    public class Meetings
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string subject { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }       
        public User User { get; set; }

        [Required]
        [Display(Name = "Virtual")]
        public Boolean AVirtual { get; set; }

        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }       
    }
}
