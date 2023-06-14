using eCinema.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCinema.Domain.DTO
{
    public class ShoppingCart:BaseEntity
    {
        internal object Tickets;

       
        public string OwnerId { get; set; }
        public eCinemaUser Owner { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}
