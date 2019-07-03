using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce_MVC_Entity.DAL;

namespace E_Commerce_MVC_Entity.Models
{
    public partial class ShoppingCarrinho
    {
        Commerce_context db = new Commerce_context();

        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "cartId";

        public static ShoppingCarrinho GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCarrinho();

            cart.ShoppingCartId = cart.GetCartId(context);

            return cart;
        }

        public static ShoppingCarrinho GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Produto product)
        {
            var cartItem = db.Carts.SingleOrDefault(c=>c.CartId == ShoppingCartId && c.ProductId == product.Id);

            if (cartItem == null)
            {
                cartItem = new Carrinho
                {
                    ProductId = product.Id,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = db.Carts.SingleOrDefault(cart => cart.CartId == ShoppingCartId && cart.ProductId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public List<Carrinho> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count =
                (from cartItems in db.Carts where cartItems.CartId == ShoppingCartId select (int?) cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.Carts
                where cartItems.CartId == ShoppingCartId
                select (int?) cartItems.Count*cartItems.Product.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(OrdemCliente customerOrder)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderedProduct = new ProdutoPedido
                {
                    ProductId = item.ProductId,
                    CustomerOrderId = customerOrder.Id,
                    Quantity = item.Count
                };

                orderTotal += (item.Count*item.Product.Price);

                db.Orderedproducts.Add(orderedProduct);
            }

            customerOrder.Amount = orderTotal;

            db.SaveChanges();

            EmptyCart();

            return customerOrder.Id;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }

                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Carts.Where(c => c.CartId == ShoppingCartId);
            foreach (Carrinho item in shoppingCart)
            {
                item.CartId = userName;
            }

            db.SaveChanges();
        }

    }
}