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
        public string Name { get; set; }

        [Required(ErrorMessage = "This field can't be empty")]
        public string Description { get; set; }           
    }
}
