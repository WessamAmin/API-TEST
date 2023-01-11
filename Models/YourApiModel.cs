using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_TEST.Models
{
    public class YourApiModel
    {
        public Inv_Ins_Class inv_Ins { get; set; }

        public List<itms> itms { get; set; }
    }
}