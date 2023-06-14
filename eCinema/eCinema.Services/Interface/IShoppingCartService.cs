using eCinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Services.Interface
{
   public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteTicketFromShoppingCart(string userID,Guid id);
        bool orderNow(string userId);
    }
}
