using API_TEST.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_TEST.Controllers
{
    public class vouchinsController : ApiController
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["API-Conn"].ConnectionString);

        //api/vouchins 
        [HttpPost]

        public IHttpActionResult Post([FromUri] voch_ins_class voch_ins)
        {
            string msg = "";

             SqlCommand cmd = new SqlCommand("voucherAPI", Connection);
             cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@vdate", DateTime.Parse(voch_ins.V_Date.ToString("yyyy-MM-dd hh: mm:ss")));
            cmd.Parameters.AddWithValue("@Bankid", voch_ins.Bank_id);
            cmd.Parameters.AddWithValue("@custid", voch_ins.cust_id);
            cmd.Parameters.AddWithValue("@Vvalue", voch_ins.V_value);
          
            Connection.Open();
            int i = cmd.ExecuteNonQuery();
            Connection.Close();

            if(i>0)
            {
                msg = "تم حفظ البيانات بنجاح";

            }
            else
            {
                msg = "لم يتم حفظ البيانات بنجاح";
            }

            return Ok(msg);
        }


        public void Put(int id, [FromBody]string value)
        {
        }

      
        public void Delete(int id)
        {
        }





    }
}
