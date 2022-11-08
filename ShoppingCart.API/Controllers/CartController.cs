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


        [HttpPost]
        [Route("AddToCart/{userName}/{productId}")]
        public IActionResult AddCart(CartItems model, string userName, int productId)
        {
            return Ok(_cartRepository.AddCartItem( userName, model,productId));
        }
        
        [HttpGet]
        [Route("GetCartsOfUser/{userName}")]
        public IActionResult GetAllPreviousCartsOfUser(string userName)
        {
            return Ok(_cartRepository.GetCartByUsername(userName));
        }
        [HttpDelete]
        [Route("DeleteCart/{userName}")]
        public IActionResult DeleteCart(string userName)
        {
            return Ok(_cartRepository.DeleteCart(userName));
        }

    }
}
