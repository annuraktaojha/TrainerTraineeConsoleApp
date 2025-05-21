using BookHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Core.Repository
{
    public interface IOrderRepository
    {
        public void AddOrder(Order order);

        public bool validateOrder(Order order);

        public double CalculateTotalCost(Order order);
    }
}
