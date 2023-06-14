using eCinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Services.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
    }
}
