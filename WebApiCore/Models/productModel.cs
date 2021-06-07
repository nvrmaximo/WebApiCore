using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Models
{
    public class productModel
    {
        public string prd_id { get; set; }

        public string prd_name { get; set; }

        public string prd_category { get; set; }

        public string prd_price { get; set; }
    }
}
