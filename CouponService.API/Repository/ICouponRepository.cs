using CouponService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponService.API.Repository
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupon>> GetAllCoupons();
        Task<IEnumerable<Offer>> GetAllOffers();
        bool CreateCoupon(Coupon data);
        Task<Coupon> UpdateCoupon(Coupon data);
        Task<Coupon> couponBycouponCode(string couponCode);
        Task<bool> DeleteCoupon(int couponId);
    }
}
