using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}
