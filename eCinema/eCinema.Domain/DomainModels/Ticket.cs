using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCinema.Domain.DTO
{
    public class Ticket:BaseEntity
    {
        
        [Required]
        public string TicketName { get; set; }
        [Required]
        public string TicketImage { get; set; }
        [Required]
        public string TicketGenre { get; set; }
        [Required]
        public DateTime TicketDate { get; set; }
        public double TicketPrice { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }

        public virtual ICollection<TicketInOrder> Orders { get; set; }


    }
}
