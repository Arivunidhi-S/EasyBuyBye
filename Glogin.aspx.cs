using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Glogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       //Response.Write(Request.QueryString.Get("param1").ToString() + "<br>");
       //Response.Write(Request.QueryString.Get("param2").ToString() + "<br>");
       // Response.Write(Request.QueryString.Get("param3").ToString()+ "<br>");
       // Response.Write(Request.QueryString.Get("param4").ToString()+ "<br>");
       // Response.Write(Request.QueryString.Get("param5").ToString() + "<br>");

       try
       {
           string Gmail = Request.QueryString.Get("param1").ToString(), GName = Request.QueryString.Get("param2").ToString(), GImg = Request.QueryString.Get("param3").ToString(), GID = Request.QueryString.Get("param4").ToString(), LogWith = Request.QueryString.Get("param5").ToString();
           int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());
           SqlConnection conn = BusinessTier.getConnection();
           conn.Open();
           SqlDataReader reader2 = BusinessTier.VaildateUserLogin(conn, Gmail.ToString(), "", "", "Google");// BusinessTier.FindDublicate(conn, "GLogin", "Gmail", Request.QueryString.Get("param1").ToString());
           if (reader2.Read())
           {
           BusinessTier.DisposeReader(reader2);           
           }
           else{BusinessTier.DisposeReader(reader2);
           BusinessTier.GLogin(conn, 1, GName.ToString(), Gmail.ToString(), GID.ToString(), GImg.ToString(), LogWith.ToString(), "1", "N");
           }
           String today = DateTime.Now.ToString();
           DateTime dtinsDate = DateTime.Parse(today);
           today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";
           SqlDataReader reader1 = BusinessTier.VaildateUserLogin(conn, Gmail.ToString(), "", "", "Google");
           if (reader1.Read())
           {
               
               HttpCookie Name = new HttpCookie("Name");
               Name.Value = reader1["Name"].ToString();
               Name.Expires = DateTime.Now.AddDays(expire);
               Response.Cookies.Add(Name);

               HttpCookie CustomerID = new HttpCookie("CustomerID");
               CustomerID.Value = reader1["BusinessID"].ToString();
               CustomerID.Expires = DateTime.Now.AddDays(expire);
               Response.Cookies.Add(CustomerID);
               BusinessTier.DisposeReader(reader1);

               string sql = "select count(*) as Cart  from AddCartMaster where DELETED=0 and buy=0 and Customerid='" + CustomerID.Value.ToString() + "' and CREATED_DATE='" + today.ToString() + "'";
               SqlCommand cmd = new SqlCommand(sql, conn);
               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {
                   HttpCookie Cart = new HttpCookie("Cart");
                   Cart.Value = reader["Cart"].ToString();
                   CustomerID.Expires = DateTime.Now.AddDays(expire);
                   Response.Cookies.Add(Cart);
                   Session["Cart"] = reader["Cart"].ToString();
               }
               BusinessTier.DisposeReader(reader);
               BusinessTier.DisposeConnection(conn);
               ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "FBLogout", "fbLogout()", true);
               ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "GoogleLogout", "signOut()", true);
               
                   Response.Redirect("index.aspx", false);
               
           }
       }
       catch (Exception ex)
       {
           InsertLogAuditTrail("1", "Glogin", "Page_Load", ex.ToString(), "Audit");
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