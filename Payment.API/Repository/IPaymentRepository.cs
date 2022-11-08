using Payment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Repository
{
    public interface IPaymentRepository
    {
        List<PaymentMethod> GetAllPaymentMethods();
        bool InsertPayment(Payments payments);
        bool InsertPaymentMethod(PaymentMethod paymentMethod);

        List<joinClass> GetPaymentsByUserName(string username);
        IQueryable<joinClass> GetOrderdPayment(string username, int orderId);
    }
}
