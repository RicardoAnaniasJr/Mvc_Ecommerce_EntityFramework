using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using E_Commerce_MVC_Entity.Models;

namespace E_Commerce_MVC_Entity.DAL
{
    public class Commerce_context:DbContext

    {
        public Commerce_context() : base("Commerce_Context")
        {

        }

        public DbSet<Categoria> Categories { get; set; }

        public DbSet<Cliente> Customers { get; set; }

        public DbSet<Produto> Products { get; set; }

        public DbSet<OrdemCliente> CustomerOrders { get; set; }

        public DbSet<ProdutoPedido> Orderedproducts { get; set; }

        public DbSet<Carrinho> Carts { get; set; }

    }
}