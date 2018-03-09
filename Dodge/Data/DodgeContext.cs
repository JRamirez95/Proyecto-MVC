using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dodge.Models;


namespace Dodge.Models
{
    public class DodgeContext : DbContext
    {
        public DodgeContext (DbContextOptions<DodgeContext> options)
            : base(options)
        {
        }

        public DbSet<Dodge.Models.Client> Cliente { get; set; }

        public DbSet<Dodge.Models.Contact> Contact { get; set; }

        

        public DbSet<Dodge.Models.SupportTickets> SupportTickets { get; set; }

        

        public DbSet<Dodge.Models.User> User { get; set; }

        

        public DbSet<Dodge.Models.Meetings> Meetings { get; set; }

        
    }
}
