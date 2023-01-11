using API_TEST.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Json.Net;
using System.IO;

namespace API_TEST.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["API-Conn"].ConnectionString);
       

        // GET api/values/5
        public string Get(int whid)
        {
            SqlDataAdapter da = new SqlDataAdapter("API_Qty", Connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@whid", whid);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Class1> lstcss = new List<Class1>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Class1 css = new Class1();
                    css.itmid = Convert.ToInt32(dt.Rows[i]["itmid"]);
                    css.nowqty = Convert.ToDecimal(dt.Rows[i]["nowqty"]);
                    css.unitid = Convert.ToInt32(dt.Rows[i]["unitid"]);
                    css.factor = Convert.ToDecimal(dt.Rows[i]["factor"]);
                    css.WholeSlsPrice = Convert.ToDecimal(dt.Rows[i]["WholeSlsPrice"]);
                    lstcss.Add(css);
                }
            }
            if (lstcss != null)
            {
                
                var jsonfile = Newtonsoft.Json.JsonConvert.SerializeObject(lstcss);
                
                return jsonfile;
            }
            else
            {
                return null;
            }
        }

        // POST api/values
        //public IHttpActionResult Post([FromBody] Inv_Ins_Class inv_Ins , [FromUri] List<itms> itms)
        //{
        //    string msg = "";
            
        //        SqlCommand cmd = new SqlCommand("API_Inv_Ins", Connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
                                  
        //            cmd.Parameters.AddWithValue("@date", inv_Ins.date);
        //            cmd.Parameters.AddWithValue("@whid", inv_Ins.whid);
        //            cmd.Parameters.AddWithValue("@custid", inv_Ins.custid);
        //            cmd.Parameters.AddWithValue("@OrigInvNo", inv_Ins.InvNo);
        //            cmd.Parameters.AddWithValue("@Payid", inv_Ins.Payid);
        //            cmd.Parameters.AddWithValue("@PayVlu", inv_Ins.PayVlu);
                
        //        DataTable datatable = new DataTable();
        //        datatable.Columns.AddRange(new DataColumn[10]
        //        { new DataColumn("total_price",typeof(double)),new DataColumn("total_discount_price",typeof(int)),
        //        new DataColumn("quantity",typeof(int)),new DataColumn("itemid",typeof(string)),
        //            new DataColumn("price",typeof(double)),  new DataColumn("FromDate",typeof(DateTime)),  new DataColumn("ToDate",typeof(DateTime)),new DataColumn("CityID",typeof(int)),new DataColumn("total_price_after_tax",typeof(int)),new DataColumn("inv_no",typeof(string))
        //        });


        //        foreach (var x in itms) {  
        //            DataRow dr = datatable.NewRow();
        //            dr["total_price"] = x.total_price;
        //            dr["total_discount_price"] = x.total_discount_price;
        //            dr["quantity"] = x.quantity;
        //            dr["itemid"] = x.itemid;
        //            dr["price"] = x.price;
        //            dr["FromDate"] = DateTime.Now;
        //            dr["ToDate"] = DateTime.Now;
        //            dr["CityID"] = 0;
        //            dr["total_price_after_tax"] = x.total_price_after_tax;
        //            dr["inv_no"] = inv_Ins.InvNo;
        //            datatable.Rows.Add(dr);
        //        }

        //        SqlBulkCopy objbulk = new SqlBulkCopy(Connection);
        //        objbulk.DestinationTableName = "Temp_API";
        //        objbulk.ColumnMappings.Add("total_price", "total_price");
        //        objbulk.ColumnMappings.Add("total_discount_price", "total_discount_price");
        //        objbulk.ColumnMappings.Add("quantity", "quantity");
        //        objbulk.ColumnMappings.Add("itemid", "sku");
        //        objbulk.ColumnMappings.Add("price", "price");
        //        objbulk.ColumnMappings.Add("FromDate", "FromDate");
        //        objbulk.ColumnMappings.Add("ToDate", "ToDate");
        //        objbulk.ColumnMappings.Add("CityID", "CityID");
        //        objbulk.ColumnMappings.Add("total_price_after_tax", "total_price_after_tax");
        //        objbulk.ColumnMappings.Add("inv_no", "inv_no");

        //        Connection.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        objbulk.WriteToServer(datatable);
        //        Connection.Close();

        //        if (i > 0)
        //        {
        //            msg = "تم حفظ البيانات بنجاح";
        //        }
        //        else
        //        {
        //            msg = "لم يتم حفظ البيانات";
        //        }
            
        //    return Ok(msg);
        //}

        // PUT api/values/5
        //public string Put(int custid, Customers customers)
        //{
        //    string msg = "";
        //    if (customers != null)
        //    {
        //        SqlCommand cmd = new SqlCommand("editcust", Connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@custid", custid);
        //        cmd.Parameters.AddWithValue("@custname", customers.custname);
        //        cmd.Parameters.AddWithValue("@custphone", customers.custphone);
        //        cmd.Parameters.AddWithValue("@custaddress", customers.custaddress);

        //        Connection.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        Connection.Close();

        //        if (i > 0)
        //        {
        //            msg = "تم تعديل البيانات بنجاح";
        //        }
        //        else
        //        {
        //            msg = "لم يتم حفظ البيانات";
        //        }
        //    }
        //    return msg;
        //}

        // DELETE api/values/5
        //public string Delete(int custid)
        //{
        //    string msg = "";
        //    SqlCommand cmd = new SqlCommand("removecust", Connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@custid", custid);
        //    Connection.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    Connection.Close();

        //    if (i > 0)
        //    {
        //        msg = "تم حذف البيانات بنجاح";
        //    }
        //    else
        //    {
        //        msg = "لم يتم حفظ البيانات";
        //    }
        //    return msg;
        //}
    }
}
