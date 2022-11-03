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

        public bool DeleteCart(int CartId)
        {
            try
            {
                var res = _cartContext.cartLists.Find(CartId);
                var data = _cartContext.cartItems.Where(x => x.CartId == CartId).ToList();
                _cartContext.cartItems.RemoveRange(data);
                _cartContext.SaveChanges();
                _cartContext.cartLists.Remove(res);
                _cartContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return true;

        }

        public List<joinclass> GetAllPreviousCartsOfUser(string userName)
        {
            var list = (from a in _cartContext.cartLists
                        join b in _cartContext.cartItems on a.CartId equals b.CartId
                        where a.UserName == userName
                        select new joinclass
                        {
                            UserName = a.UserName,
                            CartItemId = b.CartItemId,
                            Ordered = a.Ordered,
                            OrderedOn = a.OrderedOn,
                            ProductId = b.ProductId,

                        }).ToList();
            return list;
        }

        public List<joinclass> GetCart(int cartid)
        {
            var list = (from a in _cartContext.cartLists
                        join b in _cartContext.cartItems on a.CartId equals b.CartId
                        where a.CartId == cartid
                        select new joinclass
                        {
                            UserName = a.UserName,
                            CartItemId = b.CartItemId,
                            Ordered = a.Ordered,
                            OrderedOn = a.OrderedOn,
                            ProductId = b.ProductId,

                        }).ToList();
            return list;
        }

        public bool InsertCartItem(CartList model, int productId)
        {

            try
            {
                _cartContext.cartLists.Add(model);
                _cartContext.SaveChanges();

                var query = _cartContext.cartLists.Where(x => x.UserName == model.UserName).FirstOrDefault();
                var data = new CartItems()
                {
                    CartId = query.CartId,
                    ProductId = productId
                };
                _cartContext.cartItems.Add(data);
                _cartContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
    }
}
