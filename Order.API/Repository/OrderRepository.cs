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
                            PaymentConfirmation = a.PaymentConfirmation,
                            ProductName = b.ProductName,
                            Quantity = b.Quantity,
                            TotalPrice = b.TotalPrice
                        }).ToList();
            return list;
        }

        public OrderDetails InsertOrder(OrderDetails orderDetails)
        {
            try
            {
                orderDetails  = new OrderDetails
                {
                    Address = orderDetails.Address,
                    CreatedAt = DateTime.UtcNow.ToString("dd/MMMM/yyyy hh:mm:ss"),
                    Email = orderDetails.Email,
                    MobileNumber = orderDetails.Email,
                    Name = orderDetails.Name,
                    PaymentConfirmation = false,
                    UserName = orderDetails.UserName
                };
                 _orderContext.orderDetails.Add(orderDetails);
                _orderContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            return SelectOrderId(orderDetails.UserName,orderDetails.CreatedAt);
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
        public OrderDetails UpdateOrder(string userName,string orderedDate)
        {
            var order = _orderContext.orderDetails
                            .Where(x => x.UserName == userName && x.CreatedAt == orderedDate).ToList();
            foreach (var item in order)
            {
                item.PaymentConfirmation = true;
            }
            _orderContext.SaveChanges();

            return SelectOrderId(userName,orderedDate);
        }
        private OrderDetails SelectOrderId(string username,string date)
        {
            var order = _orderContext.orderDetails.Where(x => x.UserName == username && x.CreatedAt == date).SingleOrDefault();
            return order;
        }
    }
}
