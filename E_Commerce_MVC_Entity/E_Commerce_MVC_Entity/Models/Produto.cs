﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace E_Commerce_MVC_Entity.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(45, ErrorMessage = "The maximum length must be upto 45 characters only")]
        public string Name { get; set; }

        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Has to be decimal with two decimal points")]
        [Range(0,10000000000,ErrorMessage = "The maximum possible value should be upto 5 digits")]
        public Decimal Price { get;set; }


        public string Description { get; set; }

        [Display(Name = "Updated At")]
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdated { get; set; }

        public int CategoryId { get; set; }

        public virtual Categoria Category { get; set; }

        public virtual ICollection<ProdutoPedido> OrderedProducts { get; set; } 

    }
}