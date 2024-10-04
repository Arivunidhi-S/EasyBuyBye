using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class web_QwikStubsGet : System.Web.UI.Page
{
    public class Postval
    {
        public string Success { get; set; }
    }

    public static string PostData(Postval val)
    {
        string jsonplant = JsonConvert.SerializeObject(val);
        return jsonplant;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string msg = string.Empty;
        try
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Postval val = new Postval();
            if (string.IsNullOrEmpty(Request.QueryString.Get("ProductID").ToString()))
            {
                val.Success = Convert.ToString("0");
            }
            else
            {
                val.Success = Convert.ToString("1");
                msg = Request.QueryString.Get("ProductID") + "<br>" + Request.QueryString.Get("Productname") + "<br>" + Request.QueryString.Get("Size") + "<br>" + Request.QueryString.Get("PricingID") + "<br>" + Request.QueryString.Get("QPReferenceNo") + "<br>" + Request.QueryString.Get("Price") + "<br>" + Request.QueryString.Get("Name") + "<br>" + Request.QueryString.Get("Mobile") + "<br>" + Request.QueryString.Get("Email") + "<br>" + Request.QueryString.Get("Address1") + "<br>" + Request.QueryString.Get("Address2") + "<br>" + Request.QueryString.Get("PostCode") + "<br>" + Request.QueryString.Get("State") + "<br>" + Request.QueryString.Get("City") + "<br>" + Request.QueryString.Get("Country");
                BusinessTier.SendMail("arivu@e-serbadk.com", "Stubs Testing", msg, 0);
                SqlConnection con = BusinessTier.getConnection();
                con.Open();
                //SqlCommand cmd = new SqlCommand("update stubs set Status=1,Qty=1,CustomerName='" + Request.QueryString.Get("Name").ToString() + "' where ProductID='" + Request.QueryString.Get("ProductID") + "'", con);
                SqlCommand cmd = new SqlCommand("Insert into StubsReturn (Status,Qty,CustomerName,ProductID)values(1,1,'" + Request.QueryString.Get("Name").ToString() + "','" + Request.QueryString.Get("ProductID") + "')", con);
                cmd.ExecuteNonQuery();
                BusinessTier.DisposeConnection(con);
            }
            Response.Write(PostData(val) + "\n");
            //Response.Write(msg + "\n");
            Response.Write(Request.QueryString.Get("ProductID") + "\n");
            Response.Write(Request.QueryString.Get("Productname") + "\n");
            Response.Write(Request.QueryString.Get("Size") + "\n");
            Response.Write(Request.QueryString.Get("PricingID") + "\n");
            Response.Write(Request.QueryString.Get("QPReferenceNo") + "\n");
            Response.Write(Request.QueryString.Get("Price") + "\n");
            Response.Write(Request.QueryString.Get("Name") + "\n");
            Response.Write(Request.QueryString.Get("Mobile") + "\n");
            Response.Write(Request.QueryString.Get("Email") + "\n");
            Response.Write(Request.QueryString.Get("Address1") + "\n");
            Response.Write(Request.QueryString.Get("Address2") + "\n");
            Response.Write(Request.QueryString.Get("PostCode") + "\n");
            Response.Write(Request.QueryString.Get("State") + "\n");
            Response.Write(Request.QueryString.Get("City") + "\n");
            Response.Write(Request.QueryString.Get("Country"));
            Response.End();
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail("Stubs", "Page_Load", "web_QwikStubsGet", ex.ToString(), "Audit");
        }
    }

    public void createaddcart()
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            int val = 0; //BusinessTier.FindID("BusinessRegister", "BusinessID", "Contactno", Request.Form["Mobile"].ToString());
            if (val == 0)
            {
            }
            else
            { }
        }
        catch (Exception ex)
        {

        }

    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }

}