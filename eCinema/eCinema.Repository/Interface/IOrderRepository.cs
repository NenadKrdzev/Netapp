using eCinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCinema.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
    }
}
