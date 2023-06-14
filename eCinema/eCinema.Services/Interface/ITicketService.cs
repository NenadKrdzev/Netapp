using eCinema.Domain.DTO;
//using eCinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Services.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTicket();
        Ticket GetDetailsForTicket(Guid? id);
        void CreateNewTicket(Ticket p);
        void UpdeteExistingTicket(Ticket p);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteTicket(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
