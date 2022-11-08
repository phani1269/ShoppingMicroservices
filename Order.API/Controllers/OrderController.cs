using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using Order.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("InsertOrder")]
        public IActionResult InsertOrder(OrderDetails orderDetails)
        {
            var res = _orderRepository.InsertOrder(orderDetails);
            return Ok(res);
        }
        [HttpGet]
        [Route("GetOrderDetailsByUserName/{userName}")]
        public IActionResult GetOrderDetailsByUserName(string userName)
        {
            return Ok(_orderRepository.GetOrderDetailsByUserName(userName));
        }
        [HttpPost]
        [Route("InsertOrderedItems")]
        public IActionResult InsertOrderedItems(OrderedItems orderDetails)
        {
            var res = _orderRepository.InsertOrderdItems(orderDetails);
            return Ok(res);
        }

        [HttpPut]
        [Route("UpdateOrder/{username}")]
        public IActionResult UpdateOrder(string username,string date)
        {
            var details = _orderRepository.UpdateOrder(username,date);
            return Ok(details);
        }
    }
}
