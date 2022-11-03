using Order.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Repository
{
    public interface IOrderRepository
    {
        bool InsertOrder(OrderDetails orderDetails);
        bool InsertOrderdItems(OrderedItems orderedItems);

        List<joinClass> GetOrderDetailsByUserName(string userName);
    }
}
