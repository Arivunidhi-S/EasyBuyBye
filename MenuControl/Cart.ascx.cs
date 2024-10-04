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

public partial class MenuControl_Cart : System.Web.UI.UserControl
{
    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());
    string hostNameBDID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
        string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
      
        string _value = GetValue(myIP + "TestWeb");
        if (!string.IsNullOrEmpty(_value))
        {
            hostNameBDID = _value;
        }
        else
        {
            SetValue(myIP + "TestWeb", Session.SessionID);
            hostNameBDID = GetValue(myIP + "TestWeb");
        }      
        HttpCookie BDID = new HttpCookie("BDID");
        BDID.Value = hostNameBDID;
        BDID.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Set(BDID);

        Cartload(hostNameBDID);
    }

    public void Cartload(string id)
{
    HttpCookie AddCart = new HttpCookie("AddCart");
    AddCart.Value = "0";
    AddCart.Expires = DateTime.Now.AddDays(1);
    Response.Cookies.Set(AddCart);
    SqlConnection con = BusinessTier.getConnection();
    try
    {
        con.Open();
        int TotalCart=0;
        //if (Request.Cookies["CustomerID"].Value.ToString() != "0")
        //{
            SqlDataReader rcart = BusinessTier.getcart(con, Request.Cookies["CustomerID"].Value.ToString(),id);
            if (rcart.Read())
            {
                //HttpCookie Cart = new HttpCookie("Cart");
                //Cart.Value = rcart["Cart"].ToString();
                //Cart.Expires = DateTime.Now.AddDays(expire);
                //Response.Cookies.Set(Cart);
                TotalCart=Convert.ToInt32(rcart["Cart"].ToString());
            }
            BusinessTier.DisposeReader(rcart);
        //}
        //else
        //{
        //    TotalCart=0;
        //    HttpCookie Cart = new HttpCookie("Cart");
        //    Cart.Value = "0";
        //    Cart.Expires = DateTime.Now.AddDays(expire);
        //    Response.Cookies.Set(Cart);
        //}
        lblcart.Text = TotalCart.ToString();
        BusinessTier.DisposeConnection(con);
    }
    //catch (Exception ex)
    //{
    //    con.Close();
    //    HttpCookie Cart = new HttpCookie("Cart");
    //    Cart.Value = "0";
    //    Cart.Expires = DateTime.Now.AddDays(1);
    //    lblcart.Text = "0";
    //    Response.Cookies.Set(Cart);
    //    Response.Redirect("index.aspx", false);
    //}
    finally
    {
        //lblcart.Text = Request.Cookies["Cart"].Value.ToString();
        BusinessTier.DisposeConnection(con);
    }
}

    //Add Value in cokies    
    public void SetValue(string key, string value)
    {
        Response.Cookies[key].Value = value;
        Response.Cookies[key].Expires = DateTime.Now.AddDays(1); // ad    
    }

    //Get value from cokkie    
    public string GetValue(string _str)
    {
        if (Request.Cookies[_str] != null)
            return Request.Cookies[_str].Value;
        else
            return "";
    } 

    protected void btnShopCart_Click(object sender, EventArgs e)
    {
        if (lblcart.Text != "0")
        {
            if (Request.Cookies["CustomerID"].Value.ToString() != "0")
            {
                Response.Redirect("Addcart.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString() + "&Param2=" + hostNameBDID.ToString(), false);
            }
            else
            {
                Session["AddCart"] = Request.Cookies["CustomerID"].Value.ToString();
               // Response.Redirect("Login.aspx?param=0", false);
                Response.Redirect("Addcart2.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString() + "&Param2=" + hostNameBDID.ToString(), false);
            }
        }
    }
} 