using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.Configuration;
using System.Net;


public partial class MenuControl_TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie AddCart = new HttpCookie("AddCart");
        AddCart.Value = "";
        AddCart.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Set(AddCart);
        //SqlConnection con = BusinessTier.getConnection();
        string customerid = "";
       // BusinessTier.GetIPLocation(HttpContext.Current.Request.UserHostAddress);
        try
        {
            if (Request.Cookies["CustomerID"].Value.ToString()!="0")
            {
                customerid = Request.Cookies["CustomerID"].Value.ToString();
                string name = BusinessTier.GetFixedLengthString(Request.Cookies["Name"].Value.ToString(), 10);
                lblName.Text = (name.PadRight(12, '.')) + "'s Account";
                lblLog.Text = "Logout";
            }
            else
            {
                lblName.Text = "My Account";
                lblLog.Text = "Login";
                customerid = "";                
            }
            if (Response.Cookies.Count > 0)
            {
                foreach (string s in Response.Cookies.AllKeys)
                {
                    if (s == FormsAuthentication.FormsCookieName || "asp.net_sessionid".Equals(s, StringComparison.InvariantCultureIgnoreCase))
                    {
                        Response.Cookies[s].Secure = true;
                    }
                }
            }
            Session["AddCart"] = "";
        }
        catch (Exception ex)
        {
            
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "0";
            CustomerID.Expires = DateTime.Now.AddDays(1);

            HttpCookie Name = new HttpCookie("Name");
            Name.Value = "";
            Name.Expires = DateTime.Now.AddDays(1);


            Response.Cookies.Set(CustomerID);
            Response.Cookies.Set(Name);
            Session["AddCart"] = "";
            //return;
            //Response.Redirect("index.aspx", false);
            //throw ex;
             Response.Redirect(Request.RawUrl, false);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenNewTab", "window.location.reload();", true);
        }
     
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        if (lblLog.Text == "Logout")
        {            
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "0";
            CustomerID.Expires = DateTime.Now.AddDays(1);

            HttpCookie Name = new HttpCookie("Name");
            Name.Value = "";
            Name.Expires = DateTime.Now.AddDays(1);

            HttpCookie Cart = new HttpCookie("Cart");
            Cart.Value = "0";
            Cart.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Set(CustomerID);
            Response.Cookies.Set(Name);
            Response.Cookies.Set(Cart);

            Response.Redirect("index.aspx", false);
        }
        else
        {
            Response.Redirect("Login.aspx?param=0", false);
        }
    }

    protected void lnkMyAcc_Click(object sender, EventArgs e)
    {
        if (lblName.Text == "My Account") { Response.Redirect("Login.aspx", false); } else { Response.Redirect("AccountInfo.aspx", false); }
        //Response.Write("<form name='ebb' id='ebb' action='http://localhost/adminebb/AccontInfo.aspx' method='post' >");
        ////Response.Write("<form name='ebb' id='ebb' action='http://admin.easybuybye.com/AccontInfo.aspx' method='post' >");
        //Response.Write("<input type=hidden name='CustomerID' value='" + Request.Cookies["CustomerID"].Value.ToString() + "'>");
        //Response.Write("<input type=hidden name='Name' value='" + Request.Cookies["Name"].Value.ToString().ToString() + "'>");
        //Response.Write("<input type=hidden name='Cart' value='" + Request.Cookies["Cart"].Value.ToString().ToString() + "'>");
        //Response.Write("</form>");
        //Response.Write("<script>ebb.submit();</script>");
    }
}