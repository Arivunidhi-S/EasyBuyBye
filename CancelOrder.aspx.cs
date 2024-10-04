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
using System.Security.Cryptography;

public partial class CancelOrder : System.Web.UI.Page
{   
    public DataTable dtGridVal = new DataTable();   

    public string path = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            gridload();
        //}
    }

    public void gridload()
    {
        try
        {
            string param = Request.QueryString.Get("Param").ToString(), param2 = Request.QueryString.Get("Param2").ToString();
            lblOrderNo.Text = param.ToString();
            SqlConnection conn = BusinessTier.getConnection();
            conn.Open();
            string sql = "select *,'" + System.Web.Configuration.WebConfigurationManager.AppSettings["ImagePath"].ToString() + "' + imagepath as ckimg FROM VW_OrderDetails WHERE Deleted=0 and buy=1 and OrderNo='" + param.ToString() + "'  and RunningNo='" + param2.ToString() + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            sqlDataAdapter.Fill(dtGridVal);
            rpCheckout.DataSource = dtGridVal;
            rpCheckout.DataBind();
            BusinessTier.DisposeAdapter(sqlDataAdapter);
            BusinessTier.DisposeConnection(conn);
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "ReturnOrder", "gridload", ex.ToString(), "Audit");
        }
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            if (string.IsNullOrEmpty(txtAccname.Text.ToString()))
            {
                lblStatus.Text = "** Enter Account Name **";
                return;
            }
            if (string.IsNullOrEmpty(txtAccno.Text.ToString()))
            {
                lblStatus.Text = "** Enter Account number **";
                return;
            }
            if (string.IsNullOrEmpty(txtBankname.Text.ToString()))
            {
                lblStatus.Text = "** Enter Bank Name **";
                return;
            }

            string @Param = string.Empty, @Param2 = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            @Param2 = Request.QueryString.Get("Param2").ToString();

            int flg = BusinessTier.AddCartReturnCancel(conn, @Param.ToString(), @Param2.ToString().Trim(), cboReason.SelectedItem.Text.ToString(), "Full Refund", "Bank Transfer", txtAccname.Text.ToString(), txtAccno.Text.ToString(), txtBankname.Text.ToString(), "", Request.Cookies["CustomerID"].Value.ToString().Trim(), "C");
            BusinessTier.DisposeConnection(conn);
            lblStatus.Text = "** Successfully Cancel Your Order **";
            lblStatus.ForeColor = Color.Green; 
            //string URL = WebConfigurationManager.AppSettings["ImagePath"].ToString() + "\\ReturnForm.aspx?param1=" + @Param.ToString() + "&param2=" + @Param2.ToString();
            //string strLink = WebConfigurationManager.AppSettings["ImagePath"].ToString() + "\\ReturnForm.aspx?param1=17051635&param2=1";

            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(920/2);var Mtop = (screen.height/2)-(550/2);window.open( '" + URL + "', null, 'width=920,height=550,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "ReturnOrder", "btnSubmit_OnClick", ex.ToString(), "Audit");
        }
    }

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

                lbltotal.Text = (Convert.ToDecimal(lblPrice.Text.ToString()) * Convert.ToDecimal(lblQnty.Text.ToString())).ToString();

              
            }
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "ReturnOrder", "rpCheckout_ItemDataBound", ex.ToString(), "Audit");
        }

        finally
        {
            BusinessTier.DisposeConnection(conn);
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