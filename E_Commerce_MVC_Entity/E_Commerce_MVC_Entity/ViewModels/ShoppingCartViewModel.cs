using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce_MVC_Entity.Models;

namespace E_Commerce_MVC_Entity.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Carrinho> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}