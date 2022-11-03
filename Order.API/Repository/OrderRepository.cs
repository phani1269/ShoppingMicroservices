using Order.API.Context;
using Order.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public List<joinClass> GetOrderDetailsByUserName(string userName)
        {
            var list = (from a in _orderContext.orderDetails
                        join b in _orderContext.OrderedItems on a.OrderId equals b.OrderId
                        where a.UserName == userName
                        select new joinClass
                        {
                            UserName = a.UserName,
                            Name = a.Name,
                            OrderId = a.OrderId,
                            Address = a.Address,
                            CategoryName = b.CategoryName,
                            CreatedAt = a.CreatedAt,
                            Email = a.Email,
                            MobileNumber = a.MobileNumber,
                            PaymentId = a.PaymentId,
                            ProductName = b.ProductName,
                            Quantity = b.Quantity,
                            TotalPrice = b.TotalPrice
                        }).ToList();
            return list;
        }

        public bool InsertOrder(OrderDetails orderDetails)
        {
            try
            {
                _orderContext.orderDetails.Add(orderDetails);
                _orderContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            return true;
        }

        public bool InsertOrderdItems(OrderedItems orderedItems)
        {
            try
            {
                _orderContext.OrderedItems.Add(orderedItems);
                _orderContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            return true;
        }
    }
}
