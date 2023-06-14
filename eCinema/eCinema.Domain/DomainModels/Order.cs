using eCinema.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCinema.Domain.DTO
{
    public class Order: BaseEntity
    {
        public string UserId { get; set; }
        public eCinemaUser User { get; set; }

        public virtual ICollection<TicketInOrder> Tickets { get; set; }
    }
}
