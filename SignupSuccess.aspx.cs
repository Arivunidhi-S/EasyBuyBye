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

using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

public partial class SignupSuccess : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = BusinessTier.getConnection();
        string customerid = "";
        try
        {
            if (Request.Cookies["CustomerID"].Value.ToString() != "0")
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
            con.Open();          

        }
        catch (Exception ex)
        {
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "0";
            CustomerID.Expires = DateTime.Now.AddDays(1);

            HttpCookie Name = new HttpCookie("Name");
            Name.Value = "";
            Name.Expires = DateTime.Now.AddDays(1);

            HttpCookie Cart = new HttpCookie("Cart");
            Cart.Value = "";
            Cart.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Set(CustomerID);
            Response.Cookies.Set(Name);
            Response.Cookies.Set(Cart);

            Response.Redirect("index.aspx", false);
        }
        finally
        {
            con.Close();
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
            Cart.Value = "";
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
   
}