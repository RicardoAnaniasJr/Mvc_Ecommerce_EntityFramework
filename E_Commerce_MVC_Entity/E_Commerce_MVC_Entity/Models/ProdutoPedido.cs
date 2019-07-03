using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce_MVC_Entity.Models
{
    public class ProdutoPedido
    {
        [Key][Column(Order = 0)]
        public int ProductId { get; set; }

        [Key][Column(Order = 1)]
        public int CustomerOrderId { get; set; }

        public int Quantity { get; set; }

        public virtual Produto Product { get; set; }
        public virtual OrdemCliente CustomerOrder { get; set; }
    }
}