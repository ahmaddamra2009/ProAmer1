using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAmer1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="Please Enter Product Name")]
        [MaxLength(30,ErrorMessage ="Length 30 Char only")]
        public string ProductName { get; set; }
        [Required]
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
