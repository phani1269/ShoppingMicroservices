using ShoppingCart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Repository
{
    public interface ICartRepository
    {

        List<joinclass> GetCartByUsername(string userName);
        bool AddCartItem(string userName, CartItems cartItems, int productId);
        bool DeleteCart(string userName);


    }
}
