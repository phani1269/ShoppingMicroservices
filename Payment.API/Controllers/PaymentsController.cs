using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using Payment.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        [Route("GetAllPaymentMethods")]
        public IActionResult GetAllPaymentMethods()
        {
            return Ok(_paymentRepository.GetAllPaymentMethods());
        }
        [HttpGet]
        [Route("GetAllPaymentMethodsByUserName/{userName}")]
        public IActionResult GetAllPaymentMethodsByUserName(string userName)
        {
            return Ok(_paymentRepository.GetPaymentsByUserName(userName));
        }
        [HttpPost]
        [Route("InsertPaymentMethod")]
        public IActionResult InsertPaymentMethod(PaymentMethod paymentMethod)
        {
            return Ok(_paymentRepository.InsertPaymentMethod(paymentMethod));
        }
        [HttpPost]
        [Route("InsertPayments")]
        public IActionResult InsertPayments(Payments paymentMethod)
        {
            return Ok(_paymentRepository.InsertPayment(paymentMethod));
        }
    }
}
