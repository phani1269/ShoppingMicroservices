using Microsoft.EntityFrameworkCore;
using Product.GrpcService.Context;
using Product.GrpcService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.GrpcService.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponContext _couponContext;

        public CouponRepository(CouponContext couponContext)
        {
            _couponContext = couponContext;
        }
        public async Task<IEnumerable<Coupon>> GetAllCoupons()
        {
            var couponList = await _couponContext.coupons.ToListAsync();
            return couponList;
        }
        public async Task<Coupon> couponBycouponCode(string couponCode)
        {
            var coupon = await _couponContext.coupons.Where(x => x.couponCode == couponCode).FirstOrDefaultAsync();
            return coupon;

        }
        public async Task<IEnumerable<Offer>> GetAllOffers()
        {
            var couponList = await _couponContext.offers.ToListAsync();
            return couponList;
        }

        public bool CreateCoupon(Coupon data)
        {
            _couponContext.coupons.Add(data);
            _couponContext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteCoupon(int couponId)
        {
            var res = await _couponContext.coupons.FindAsync(couponId);
            var result = _couponContext.coupons.Remove(res);
            await _couponContext.SaveChangesAsync();
            return true;
        }

        

        

        public async Task<Coupon> UpdateCoupon(Coupon data)
        {
            var res = await _couponContext.coupons.Where(x => x.couponId == data.couponId).SingleOrDefaultAsync();
            _couponContext.coupons.Remove(res);
            _couponContext.coupons.Update(data);
            await _couponContext.SaveChangesAsync();
            return null;
        }

        public async Task<Offer> GetOfferDetails(int offerId)
        {
           return await _couponContext.offers.Where(x => x.OfferId == offerId).SingleOrDefaultAsync();

        }
    }
}
