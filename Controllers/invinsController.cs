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

namespace API_TEST.Controllers
{
    public class invinsController : ApiController
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["API-Conn"].ConnectionString);
        // GET: api/invins
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/invins/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/invins
        //public IHttpActionResult Post([FromBody] YourApiModel apiModel)
        //{
        //    string msg = "";




        //    SqlCommand cmd = new SqlCommand("API_Inv_Ins", Connection);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@date", DateTime.Parse(apiModel.inv_Ins.date.ToString("yyyy-MM-dd hh:mm:ss")));
        //    cmd.Parameters.AddWithValue("@whid", apiModel.inv_Ins.whid);
        //    cmd.Parameters.AddWithValue("@custid", apiModel.inv_Ins.custid);
        //    cmd.Parameters.AddWithValue("@OrigInvNo", apiModel.inv_Ins.InvNo);
        //    cmd.Parameters.AddWithValue("@Payid", apiModel.inv_Ins.Payid);
        //    cmd.Parameters.AddWithValue("@PayVlu", apiModel.inv_Ins.PayVlu);


        //    DataTable datatable = new DataTable();
        //    datatable.Columns.AddRange(new DataColumn[11]
        //    { new DataColumn("total_price",typeof(double)),new DataColumn("total_discount_price",typeof(int)),
        //        new DataColumn("quantity",typeof(int)),new DataColumn("itemid",typeof(string)),
        //            new DataColumn("price",typeof(double)),  new DataColumn("FromDate",typeof(DateTime)), 
        //        new DataColumn("ToDate",typeof(DateTime)),new DataColumn("CityID",typeof(int)),
        //        new DataColumn("total_price_after_tax",typeof(int)),
        //        new DataColumn("inv_no",typeof(string)),new DataColumn("unitid",typeof(int))
        //    });


        //    foreach (var x in apiModel.itms)
        //    {
        //        DataRow dr = datatable.NewRow();
        //        dr["total_price"] = x.total_price;
        //        dr["total_discount_price"] = x.total_discount_price;
        //        dr["quantity"] = x.quantity;
        //        dr["itemid"] = x.itemid;
        //        dr["price"] = x.price;
        //        dr["FromDate"] = DateTime.Now;
        //        dr["ToDate"] = DateTime.Now;
        //        dr["CityID"] = 0;
        //        dr["total_price_after_tax"] = x.total_price_after_tax;
        //        dr["inv_no"] = apiModel. inv_Ins.InvNo;
        //        dr["unitid"] = x.unitid;
        //        datatable.Rows.Add(dr);
        //    }

        //    SqlBulkCopy objbulk = new SqlBulkCopy(Connection);
        //    objbulk.DestinationTableName = "Temp_API";
        //    objbulk.ColumnMappings.Add("total_price", "total_price");
        //    objbulk.ColumnMappings.Add("total_discount_price", "total_discount_price");
        //    objbulk.ColumnMappings.Add("quantity", "quantity");
        //    objbulk.ColumnMappings.Add("itemid", "sku");
        //    objbulk.ColumnMappings.Add("price", "price");
        //    objbulk.ColumnMappings.Add("FromDate", "FromDate");
        //    objbulk.ColumnMappings.Add("ToDate", "ToDate");
        //    objbulk.ColumnMappings.Add("CityID", "CityID");
        //    objbulk.ColumnMappings.Add("total_price_after_tax", "total_price_after_tax");
        //    objbulk.ColumnMappings.Add("inv_no", "inv_no");
        //    objbulk.ColumnMappings.Add("unitid", "unitid");

        //    Connection.Open();
        //    objbulk.WriteToServer(datatable);
        //    int i = cmd.ExecuteNonQuery();                          
        //    Connection.Close();

        //    if (i > 0)
        //    {
        //        msg = "تم حفظ البيانات بنجاح";
        //    }
        //    else
        //    {
        //        msg = "لم يتم حفظ البيانات";
        //    }

        //    return Ok(msg);
        //}

        // PUT: api/invins/5

        public IHttpActionResult Post([FromUri] Inv_Ins_Class inv_Ins, [FromBody] List<itms> itms)
        {
            string msg = "";
           
            SqlCommand cmd = new SqlCommand("API_Inv_Ins", Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@date", DateTime.Parse(inv_Ins.date.ToString("yyyy-MM-dd hh: mm:ss")));
            cmd.Parameters.AddWithValue("@whid", inv_Ins.whid);
            cmd.Parameters.AddWithValue("@custid", inv_Ins.custid);
            cmd.Parameters.AddWithValue("@OrigInvNo", inv_Ins.InvNo);
            cmd.Parameters.AddWithValue("@Payid", inv_Ins.Payid);
            cmd.Parameters.AddWithValue("@PayVlu", inv_Ins.PayVlu);

            DataTable datatable = new DataTable();
            datatable.Columns.AddRange(new DataColumn[11]
            { new DataColumn("total_price",typeof(double)),new DataColumn("total_discount_price",typeof(int)),
                new DataColumn("quantity",typeof(int)),new DataColumn("itemid",typeof(string)),
                    new DataColumn("price",typeof(double)),  new DataColumn("FromDate",typeof(DateTime)),
                new DataColumn("ToDate",typeof(DateTime)),new DataColumn("CityID",typeof(int)),
                new DataColumn("total_price_after_tax",typeof(int)),
                new DataColumn("inv_no",typeof(string)),new DataColumn("unitid",typeof(int))
            });


            foreach (var x in itms)
            {
                DataRow dr = datatable.NewRow();
                dr["total_price"] = x.total_price;
                dr["total_discount_price"] = x.total_discount_price;
                dr["quantity"] = x.quantity;
                dr["itemid"] = x.itemid;
                dr["price"] = x.price;
                dr["FromDate"] = DateTime.Now;
                dr["ToDate"] = DateTime.Now;
                dr["CityID"] = 0;
                dr["total_price_after_tax"] = x.total_price_after_tax;
                dr["inv_no"] = inv_Ins.InvNo;
                dr["unitid"] = x.unitid;
                datatable.Rows.Add(dr);
            }

            SqlBulkCopy objbulk = new SqlBulkCopy(Connection);
            objbulk.DestinationTableName = "Temp_API";
            objbulk.ColumnMappings.Add("total_price", "total_price");
            objbulk.ColumnMappings.Add("total_discount_price", "total_discount_price");
            objbulk.ColumnMappings.Add("quantity", "quantity");
            objbulk.ColumnMappings.Add("itemid", "sku");
            objbulk.ColumnMappings.Add("price", "price");
            objbulk.ColumnMappings.Add("FromDate", "FromDate");
            objbulk.ColumnMappings.Add("ToDate", "ToDate");
            objbulk.ColumnMappings.Add("CityID", "CityID");
            objbulk.ColumnMappings.Add("total_price_after_tax", "total_price_after_tax");
            objbulk.ColumnMappings.Add("inv_no", "inv_no");
            objbulk.ColumnMappings.Add("unitid", "unitid");

            Connection.Open();
            objbulk.WriteToServer(datatable);
            int i = cmd.ExecuteNonQuery();
            Connection.Close();

            if (i > 0)
            {
                msg = "تم حفظ البيانات بنجاح";
            }
            else
            {
                msg = "لم يتم حفظ البيانات";
            }

            return Ok(msg);
        }


        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/invins/5
        public void Delete(int id)
        {
        }
    }
}
