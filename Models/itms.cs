using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_TEST.Models
{
    public class itms
    {
        public string itemid { get; set; }

        public int quantity { get; set; }

        public double price { get; set; }

        public double total_price { get; set; }

        public int total_discount_price { get; set; }

        public int total_price_after_tax { get; set; }

        public string inv_no { get; set; }

        public int unitid { get; set; }
    }
}