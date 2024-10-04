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


public partial class Wishlist : System.Web.UI.Page
{
    public DataTable dtMenuItems = new DataTable();

    public DataTable dtSubMenuItems = new DataTable();

    public DataTable dtGridVal = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    public string path = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridload();
        }
    }

    public void gridload()
    {
        try
        {
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            string sql = "select *, '" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM Vw_WishList WHERE Customerid='" + Request.Cookies["CustomerID"].Value.ToString() + "' and IsCOD=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(dtGridVal);
            rpCheckout.DataSource = dtGridVal;
            rpCheckout.DataBind();
            BusinessTier.DisposeAdapter(sqlDataAdapter);
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Wishlist", "gridload", ex.ToString(), "Audit");
        }
    }

    protected void rpCheckout_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        try
        {
            TextBox txtval = e.Item.FindControl("txtval") as TextBox;
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            if (e.CommandName == "plus")
            {

                HiddenField hdProductID = (HiddenField)e.Item.FindControl("hdProductID");
                HiddenField hdPricingID = (HiddenField)e.Item.FindControl("hdPricingID");

                String Insdate = DateTime.Now.ToString();
                DateTime dtinsDate = DateTime.Parse(Insdate);
                Insdate = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";
                SqlDataReader rd = BusinessTier.getDuplicate(conn, hdProductID.Value, Request.Cookies["CustomerID"].Value.ToString(), Insdate.ToString());
                if (rd.Read())
                {

                    int AddcartID = Convert.ToInt32(rd["AddcartID"].ToString());
                    int dtqty = Convert.ToInt32(rd["Qnty"].ToString());
                    BusinessTier.DisposeReader(rd);
                    int flg = BusinessTier.AddCart(conn, AddcartID, Convert.ToInt32(hdProductID.Value.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), Convert.ToInt32(hdPricingID.Value.ToString().Trim()), 1, Request.Cookies["CustomerID"].Value.ToString(),"0", "U");
                }
                else
                {
                    BusinessTier.DisposeReader(rd);
                    int flg = BusinessTier.AddCart(conn, 1, Convert.ToInt32(hdProductID.Value.ToString().Trim()), Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), Convert.ToInt32(hdPricingID.Value.ToString().Trim()), 1, Request.Cookies["CustomerID"].Value.ToString(),"0", "N");
                }
                BusinessTier.DisposeConnection(conn);
                Response.Redirect("AddCart.aspx?Param=" + Request.Cookies["CustomerID"].Value.ToString(), false);
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdWishlistID = e.Item.FindControl("hdWishlistID") as HiddenField;
                int flg = BusinessTier.AddWishlist(conn, Convert.ToInt32(hdWishlistID.Value.ToString()), 0, Convert.ToInt32(Request.Cookies["CustomerID"].Value.ToString()), 0, Request.Cookies["CustomerID"].Value.ToString(), "D");
                gridload();
            }

        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Wishlist", "rpCheckout_ItemCommand", ex.ToString(), "Audit");
        }
    }

    protected void btnbuy_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            // BusinessTier.InsertShippingAddress(conn, 1, txtName.Text.ToString().Trim(), txtMobile.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtAddress1.Text.ToString().Trim(), txtAddress2.Text.ToString().Trim(), "", txtPostCode.Text.ToString().Trim(), txtCity.Text.ToString().Trim(), txtState.Text.ToString().Trim(), txtCountry.Text.ToString().Trim(), Request.Cookies["CustomerID"].Value.ToString(), "", "", "", Request.Cookies["CustomerID"].Value.ToString(), "N");
            string shipingid = BusinessTier.MaxID(conn, "ShippingAddress", "ShippingID", Request.Cookies["CustomerID"].Value.ToString());
            Response.Redirect("ShippingAddress.aspx?Param=" + shipingid.ToString(), false);
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {

            BusinessTier.DisposeConnection(conn);
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "Wishlist", "btnbuy_OnClick", ex.ToString(), "Audit");
        }
    }

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }

    private void txt(TextBox txtbx, string strRet)
    {
        txtbx.Attributes["placeholder"] = strRet;
        txtbx.CssClass = "form-control1 txtbx";
        txtbx.Focus();
    }

    private void ddl(DropDownList txtbx, string strRet)
    {
        txtbx.Attributes["placeholder"] = strRet;
        txtbx.CssClass = "form-control1 txtbx";
        txtbx.Focus();
    }

    protected void rpCheckout_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            HiddenField hdTotalStock = e.Item.FindControl("hdTotalStock") as HiddenField;
            LinkButton lbplus = e.Item.FindControl("lbplus") as LinkButton;
            Label lblsoldout = e.Item.FindControl("lblsoldout") as Label;
           if (hdTotalStock.Value == "0")
           {
               lblsoldout.Visible = true;
               lbplus.Visible = false;
           }
           else
           {
               lblsoldout.Visible = false;
               lbplus.Visible = true; }
        }
    }
}