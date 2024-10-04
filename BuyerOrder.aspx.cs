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

public partial class BuyerOrder : System.Web.UI.Page
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

    protected void cboSortby_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        gridload();
    }

    public void gridload()
    {
        try
        {
            string condition = string.Empty;
            if (string.IsNullOrEmpty(cboSortby.SelectedValue.ToString()))
            {
                condition = "5";
            }
            else
            {
                condition = cboSortby.SelectedValue.ToString();
            }
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            string sql = BusinessTier.getBuyerOrder(condition, Request.Cookies["CustomerID"].Value.ToString());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(dtGridVal);
            rpCheckout.DataSource = dtGridVal;
            rpCheckout.DataBind();
            BusinessTier.DisposeAdapter(sqlDataAdapter);
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "BuyerOrder", "gridload", ex.ToString(), "Audit");
        }
    }

    protected void rpCheckout_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        try
        {           
            conn.Open();
            if (e.CommandName == "CancelReturn")
            {
                Button btnCancel = (Button)e.Item.FindControl("btnCancel");
                HiddenField hdAddcartID = (HiddenField)e.Item.FindControl("hdAddcartID");
                HiddenField hdOrderNo = (HiddenField)e.Item.FindControl("hdOrderNo");
                HiddenField ID = (HiddenField)e.Item.FindControl("hdRunningNo");
                if (btnCancel.Text == "Cancel")
                {
                    String today = DateTime.Now.AddDays(1).ToString();
                    DateTime dtinsDate = DateTime.Parse(today);
                    today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";

                    String nextday = DateTime.Now.AddDays(-1).ToString();
                    DateTime dtnextDate = DateTime.Parse(nextday);
                    nextday = dtnextDate.Month + "/" + dtnextDate.Day + "/" + dtnextDate.Year + " 00:00:00";

                    string sql = "select * FROM VW_OrderDetails WHERE Deleted=0 and buy=1 and status=1 and Deliver=0 and Shipped=0 and AddcartID='" + hdAddcartID.Value.ToString().Trim() + "' and created_date between '" + nextday.ToString() + "' and '" + today.ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql, conn);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        Response.Redirect("CancelOrder.aspx?Param=" + hdOrderNo.Value.ToString().Trim() + "&Param2=" + ID.Value.ToString(), false);
                    }
                    else
                    {
                        lblStatus.Text = "** You have to Cancel within 1 day **";
                    }
                    BusinessTier.DisposeReader(reader1);
                }
                else if (btnCancel.Text == "Return")
                {
                    String today = DateTime.Now.AddDays(1).ToString();
                    DateTime dtinsDate = DateTime.Parse(today);
                    today = dtinsDate.Month + "/" + dtinsDate.Day + "/" + dtinsDate.Year + " 00:00:00";


                    String nextday = DateTime.Now.AddDays(-7).ToString();
                    DateTime dtnextDate = DateTime.Parse(nextday);
                    nextday = dtnextDate.Month + "/" + dtnextDate.Day + "/" + dtnextDate.Year + " 00:00:00";

                    string sql = "select * FROM VW_OrderDetails WHERE Deleted=0 and buy=1 and status=1 and Shipped=1 and AddcartID='" + hdAddcartID.Value.ToString().Trim() + "' and DeliverDate between '" + nextday.ToString() + "' and '" + today.ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql, conn);
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        Response.Redirect("ReturnOrder.aspx?Param=" + hdOrderNo.Value.ToString().Trim() + "&Param2=" + ID.Value.ToString(), false);
                    }
                    else
                    {
                        lblStatus.Text = "** You have to return within 7 days of delivery **";
                    }
                    BusinessTier.DisposeReader(reader1);

                }
                BusinessTier.DisposeConnection(conn);
                lblStatus.ForeColor = Color.Red;
                gridload();
            }

        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "BuyerOrder", "rpCheckout_ItemCommand", ex.ToString(), "Audit");
        }

        finally { BusinessTier.DisposeConnection(conn); }
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
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "BuyerOrder", "btnbuy_OnClick", ex.ToString(), "Audit");
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

    //protected void rpCheckout_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
        
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        RepeaterItem item = e.Item;
    //        HiddenField hdTotalStock = e.Item.FindControl("hdTotalStock") as HiddenField;
    //        LinkButton lbplus = e.Item.FindControl("lbplus") as LinkButton;
    //        Label lblsoldout = e.Item.FindControl("lblsoldout") as Label;
    //       if (hdTotalStock.Value == "0")
    //       {
    //           lblsoldout.Visible = true;
    //           lbplus.Visible = false;
    //       }
    //       else
    //       {
    //           lblsoldout.Visible = false;
    //           lbplus.Visible = true; }
    //    }
    //}

    protected void rpCheckout_ItemDataBound(object source, RepeaterItemEventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
            RepeaterItem item = e.Item;
            Label lblPrice = (Label)e.Item.FindControl("lblPrice");
            Label lbltotal = (Label)e.Item.FindControl("lbltotal");
            Label lblQnty = (Label)e.Item.FindControl("lblQnty");
            Label lblShipped = (Label)e.Item.FindControl("lblShipped");
            Label lblDelivered = (Label)e.Item.FindControl("lblDelivered");
            Button btnCancel = (Button)e.Item.FindControl("btnCancel");
            Label lblStatus = (Label)e.Item.FindControl("lblStatus");
           
            lbltotal.Text = (Convert.ToDecimal(lblPrice.Text.ToString()) * Convert.ToDecimal(lblQnty.Text.ToString())).ToString();

            if (lblStatus.Text == "Processing...")
            {
                lblStatus.ForeColor = Color.Red;
                btnCancel.Text = "Cancel";
            }
            else if (lblStatus.Text == "Ready to Ship")
            {
                lblStatus.ForeColor = Color.Blue;
                btnCancel.Text = "Cancel";
            }

            else if (lblStatus.Text == "Shipped" || lblStatus.Text == "Delivered")
            {
                lblStatus.ForeColor = Color.Green;
                btnCancel.Text = "Return";
            }

            //if (lblDelivered.Text == "Yes")
            //{
            //    lblDelivered.ForeColor = Color.Green;              
            //}
            //else
            //{
            //    lblDelivered.ForeColor = Color.Red;              
            //}
        }
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "BuyerOrder", "rpCheckout_ItemDataBound", ex.ToString(), "Audit");
        }

        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }
}