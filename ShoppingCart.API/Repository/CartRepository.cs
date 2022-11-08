using Microsoft.EntityFrameworkCore;
using ShoppingCart.API.Context;
using ShoppingCart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.API.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly CartContext _cartContext;

        public CartRepository(CartContext cartContext)
        {
            _cartContext = cartContext;
        }


        public List<joinclass> GetCartByUsername(string userName)
        {
            var cart = GetJoinclasses(userName);
            List<joinclass> cartList = new List<joinclass>();
            if (cart.Count != 0 )
            {
                 return cart;

            }
            if (cart.Count==0 && CheckUsernameExist(userName))
            {
                return cartList;
            }
            // if it is first attempt create new
            var newCart = new CartList
            {
                UserName = userName,
                Ordered = false,
                CreatedOn = DateTime.UtcNow.ToString("dd MMMM yyyy hh mm ss"),
            };
            _cartContext.cartLists.Add(newCart);
            _cartContext.SaveChanges();
            return GetJoinclasses(userName);


        }

        public bool AddCartItem(string userName, CartItems cartItems, int productId)
        {

            var query = _cartContext.cartLists.Where(x => x.UserName == userName).FirstOrDefault();

            var data = new CartItems
            {
                CartId = query.CartId,
                Color = cartItems.Color,
                Price = cartItems.Price,
                ProductId = productId,
                Quantity = cartItems.Quantity
            };
            _cartContext.cartItems.Add(data);
            _cartContext.SaveChanges();
            return true;
        }

        public bool DeleteCart(string userName)
        {
            var id = _cartContext.cartLists.Where(x => x.UserName == userName).FirstOrDefault();
            var res = _cartContext.cartItems.Where(x=>x.CartId==id.CartId).ToList();
            _cartContext.cartItems.RemoveRange(res);
            _cartContext.SaveChanges();

            

            return true;
        }

        private bool CheckUsernameExist(string userName)
        {
            return  _cartContext.cartLists.Any(x => x.UserName == userName);
        }

        private List<joinclass> GetJoinclasses(string userName)
        {
            var cart = (from a in _cartContext.cartLists
                        join b in _cartContext.cartItems on a.CartId equals b.CartId
                        where a.UserName == userName
                        select new joinclass
                        {
                            UserName = a.UserName,
                            CartItemId = b.CartItemId,
                            Ordered = a.Ordered,
                            CreatedOn = a.CreatedOn,
                            ProductId = b.ProductId,
                            Color = b.Color,
                            Price = b.Price,
                            CartId = b.CartId,
                            Quantity = b.Quantity

                        }).ToList();
            return cart;
        }




    }
}
