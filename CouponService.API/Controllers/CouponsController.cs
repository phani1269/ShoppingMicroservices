using CouponService.API.Models;
using CouponService.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponsController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpPost]
        public ActionResult CreateCoupon(Coupon coupon)
        {
            var result = _couponRepository.CreateCoupon(coupon);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetcouponBycouponCode")]
        public async Task<ActionResult> GetcouponBycouponCode(string couponCode)
        {
            var res = await _couponRepository.couponBycouponCode(couponCode);
            return Ok(res);
        }
        [HttpGet]
        [Route("GetAllCoupons")]
        public async Task<ActionResult> GetAllCoupons()
        {
            var res = await _couponRepository.GetAllCoupons();
            return Ok(res);
        }
        [HttpGet]
        [Route("GetAllOffers")]
        public async Task<ActionResult> GetAllOffers()
        {
            var res = await _couponRepository.GetAllOffers();
            return Ok(res);
        }
        [HttpPut]
        [Route("UpdateCoupon")]
        public async Task<ActionResult> UpdateCoupon(Coupon details)
        {
            var pay = await _couponRepository.UpdateCoupon(details);
            return Ok(pay);
        }
        [HttpDelete]
        [Route("DeleteCoupon")]
        public async Task<ActionResult> DeleteCoupon(int couponId)
        {
            var pay = await _couponRepository.DeleteCoupon(couponId);
            return Ok(pay);
        }

    }
}
