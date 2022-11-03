using ShoppingCart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Repository
{
    public interface ICartRepository
    {
        bool InsertCartItem(CartList model, int productId);
        List<joinclass> GetCart(int cartid);
        List<joinclass> GetAllPreviousCartsOfUser(string userName);

        bool DeleteCart(int CartId);


    }
}
