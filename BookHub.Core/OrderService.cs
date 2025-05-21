using BookHub.Core.Entities;
using BookHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Core
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public bool PlaceOrder(Order order)
        {
            if (order.Books == null || order.Books.Count == 0)
                return false;
            _orderRepository.AddOrder(order);
            return true;
        }

        public bool ValidateOrderDetails(Order order) 
        {
            return true;
        }
        // Other methods... 
    }
}
