using Payment.API.Context;
using Payment.API.Migrations;
using Payment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentsContext _paymentcontext;

        public PaymentRepository(PaymentsContext paymentcontext)
        {
            _paymentcontext = paymentcontext;
        }

        public List<PaymentMethod> GetAllPaymentMethods()
        {
            var lisst = _paymentcontext.paymentMethods.ToList();
            return lisst;
        }

        public List<joinClass> GetPaymentsByUserName(string username)
        {
            var list = (from a in _paymentcontext.payments
                        join b in _paymentcontext.paymentMethods on a.PaymentMethodId equals b.PaymentMethodId
                        where a.UserName == username
                        select new joinClass
                        {
                            UserName = a.UserName,
                            Id = a.Id,
                            PaymentMethodId = b.PaymentMethodId,
                            AmountPaid = a.AmountPaid,
                            AmountReduced = a.AmountReduced,
                            ShipingCharges = a.ShipingCharges,
                            TotalAmount = a.TotalAmount,
                            Type = b.Type,
                            CreatedAt = a.CreatedAt,
                            Provider = b.Provider,
                            Reason = b.Reason,

                        }).ToList();
            return list;

        }

        public bool InsertPayment(Payments payments)
        {
            _paymentcontext.payments.Add(payments);
            _paymentcontext.SaveChanges();
            return true;
        }

        public bool InsertPaymentMethod(PaymentMethod paymentMethod)
        {
            _paymentcontext.paymentMethods.Add(paymentMethod);
            _paymentcontext.SaveChanges();
            return true;
        }
    }
}
