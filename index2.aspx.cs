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

public partial class index2 : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    public DataTable dtRecentitems1 = new DataTable();

    public DataTable dtRecentitems2 = new DataTable();

    public DataTable dtRecentitems3 = new DataTable();

    public DataTable dtFeatureitems = new DataTable();

    public DataTable dtMenuItems = new DataTable();

    public DataTable dtSubMenuItems = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie AddCart = new HttpCookie("AddCart");
        AddCart.Value = "";
        AddCart.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Set(AddCart);
        SqlConnection con = BusinessTier.getConnection();
        string customerid = "";
       
        try
        {
            if (!(string.IsNullOrEmpty(Request.Cookies["CustomerID"].Value.ToString())))
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

            SqlDataReader rdFeatureitems = BusinessTier.getFeatureitems(con);
            dtFeatureitems.Load(rdFeatureitems);
            BusinessTier.DisposeReader(rdFeatureitems);

            SqlDataReader rdRecentitems = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion1"].ToString());
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);

            SqlDataReader rdRecentitems1 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion2"].ToString());
            dtRecentitems1.Load(rdRecentitems1);
            BusinessTier.DisposeReader(rdRecentitems1);

            SqlDataReader rdRecentitems2 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion3"].ToString());
            dtRecentitems2.Load(rdRecentitems2);
            BusinessTier.DisposeReader(rdRecentitems2);

            SqlDataReader rdRecentitems3 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexMenFashion1"].ToString());
            dtRecentitems3.Load(rdRecentitems3);
            BusinessTier.DisposeReader(rdRecentitems3);

            SqlDataReader readerMenulist = BusinessTier.getMenuList1(con);
            dtMenuItems.Load(readerMenulist);
            BusinessTier.DisposeReader(readerMenulist);

            if (!(string.IsNullOrEmpty(customerid.ToString())))
            {
                SqlDataReader rcart = BusinessTier.getcart(con, customerid.ToString(),"0");
                if (rcart.Read())
                {
                    //lblcart.Text = "5";
                    lblcart.Text = rcart["Cart"].ToString();
                    HttpCookie Cart = new HttpCookie("Cart");
                    Cart.Value = rcart["Cart"].ToString();
                    Cart.Expires = DateTime.Now.AddDays(expire);
                    Response.Cookies.Set(Cart);
                }
                BusinessTier.DisposeReader(rcart);
            }
        }
        catch (Exception ex)
        {
            con.Close();
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "";
            CustomerID.Expires = DateTime.Now.AddDays(1);

            HttpCookie Name = new HttpCookie("Name");
            Name.Value = "";
            Name.Expires = DateTime.Now.AddDays(1);

            HttpCookie Cart = new HttpCookie("Cart");
            Cart.Value = "";
            Cart.Expires = DateTime.Now.AddDays(1);
            lblcart.Text = "0";
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

    protected void btnShopCart_Click(object sender, EventArgs e)
    {
        if (lblcart.Text != "0")
        {
            Response.Redirect("Addcart.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString(), false);
        }
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        if (lblLog.Text == "Logout")
        {
            HttpCookie CustomerID = new HttpCookie("CustomerID");
            CustomerID.Value = "";
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
            Response.Redirect("Login.aspx", false);
        }
    }


}