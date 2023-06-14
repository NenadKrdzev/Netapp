using eCinema.Domain.DomainModels;
using eCinema.Domain.DTO;
using eCinema.Repository.Interface;
using eCinema.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCinema.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _emailRepository;
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<EmailMessage> emailRepository, IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<TicketInOrder> ticketInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _emailRepository = emailRepository;
        }

        public bool deleteTicketFromShoppingCart(string userId,Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var ticketToDelete = userShoppingCart.TicketInShoppingCarts
                  .Where(z => z.TicketId.Equals(id))
                 .FirstOrDefault();

                userShoppingCart.TicketInShoppingCarts.Remove(ticketToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var AllTickets = userShoppingCart.TicketInShoppingCarts.ToList();

            var ticketsPrice =AllTickets.Select(z => new
            {
                TicketPrice = z.Ticket.TicketPrice,
                Quantity = z.Quantity
            }).ToList();

            double total = 0.0;

            foreach (var item in ticketsPrice)
            {
                total += item.TicketPrice * item.Quantity;
            }

            ShoppingCartDto ShoppingCartDtoItem = new ShoppingCartDto
            {
                TicketInShoppingCarts1 = AllTickets,
                TotalPrice = total
            };
            return ShoppingCartDtoItem;
        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                EmailMessage emailMessage = new EmailMessage();
                emailMessage.MailTo = loggedInUser.Email;
                emailMessage.Subject = "Order created";
                emailMessage.Status = false;


                Order orderItem = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    User = loggedInUser
                };

                this._orderRepository.Insert(orderItem);

                List<TicketInOrder> ticketInOrders = new List<TicketInOrder>();

                var result = userShoppingCart.TicketInShoppingCarts
                    .Select(z => new TicketInOrder
                    {
                        Id = Guid.NewGuid(),
                        OrderId = orderItem.Id,
                        TicketId = z.Ticket.Id,
                        SelectedTicket = z.Ticket,
                        UserOrder = orderItem,
                        Quantity = z.Quantity
                    }).ToList();

                //StringBuilder sb = new StringBuilder();

                //sb.AppendLine("Your order is: ");
                //var totalPrice = 0.0;

                //for (int i = 1; i <=result.Count(); i++)
                //{
                //    var item = result[i - 1];
                //    totalPrice += item.Quantity * item.SelectedTicket.TicketPrice;
                //    sb.AppendLine(i.ToString() + "."+ item.SelectedTicket.TicketName+" with price of "+item.SelectedTicket.TicketPrice+"$ and quantity of "+item.Quantity);
                //}

                //sb.AppendLine("Your total is: " + totalPrice.ToString());

                //emailMessage.Content = sb.ToString();

                ticketInOrders.AddRange(result);

                foreach (var item in ticketInOrders)
                {
                    this._ticketInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.TicketInShoppingCarts.Clear();

                //this._emailRepository.Insert(emailMessage);

                this._userRepository.Update(loggedInUser);
                return true;
            }
            return false;
        }
    }
}
