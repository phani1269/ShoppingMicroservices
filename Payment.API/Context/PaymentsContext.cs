using Microsoft.EntityFrameworkCore;
using Payment.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Context
{
    public class PaymentsContext:DbContext
    {
        public PaymentsContext()
        {

        }

        public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options)
        {
        }

        public DbSet<Payments> payments { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }


    }
}
