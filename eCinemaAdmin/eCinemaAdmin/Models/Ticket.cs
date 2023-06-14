using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCinemaAdmin.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string TicketName { get; set; }
        public string TicketImage { get; set; }
        public string TicketGenre { get; set; }
        public DateTime TicketDate { get; set; }
        public double TicketPrice { get; set; }
    }
}
