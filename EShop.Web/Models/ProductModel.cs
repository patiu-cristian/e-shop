using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage ="This field can't be empty")]
        [MinLength(4,ErrorMessage ="Minimum length 4")]
        public string DenumireProdus { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        public string Descriere { get; set; }
             
    }
}
