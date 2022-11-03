using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Models;
using ShoppingCart.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("GetCartDetails")]
        public IActionResult GetCartDetails(int cartId)
        {
          // HttpContext.User.FindFirst("");
          return Ok( _cartRepository.GetCart(cartId));
        }
        [HttpPost]
        [Route("InsertCart")]
        public IActionResult InsertCart(CartList model, int productId)
        {
           return Ok( _cartRepository.InsertCartItem(model, productId));
        }
        [HttpGet]
        [Route("GetAllPreviousCartsOfUser/{userName}")]
        public IActionResult GetAllPreviousCartsOfUser(string userName)
        {
            return Ok(_cartRepository.GetAllPreviousCartsOfUser(userName));
        }
        [HttpDelete]
        [Route("DeleteCart")]
        public IActionResult DeleteCart(int cartId)
        {
            return Ok(_cartRepository.DeleteCart(cartId));
        }

    }
}
