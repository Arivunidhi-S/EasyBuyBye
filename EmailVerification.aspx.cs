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
using System.Threading;

public partial class EmailVerification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        connMenu.Open();
        try
        {
            Session["AddCart"] = "0";
            string @Param = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();

            //if (@Param == "1")
            //{
            //    int count = 0;

            //   //SqlDataReader rd = BusinessTier.FindDublicate(connMenu, "MyCyberSale", "countid", "1");
            //    string sql1 = "select * FROM MyCyberSale WHERE countid = 1";
            //    SqlCommand cmd1 = new SqlCommand(sql1, connMenu);
            //    SqlDataReader rd = cmd1.ExecuteReader();

            //     if (rd.Read())
            //     {
            //         count = Convert.ToInt32(rd["hitcount"].ToString());
            //         count = count + 1;
            //     }
            //     BusinessTier.DisposeReader(rd);
            //     string sql = "update MyCyberSale set hitcount=" + count + " where countid = 1";
            //     SqlCommand cmd = new SqlCommand(sql, connMenu);
            //     cmd.ExecuteNonQuery();
            //     BusinessTier.DisposeConnection(connMenu);
            //    Response.Redirect("index.aspx", false);
            //}
            //else 
            //{
                string sql = "update BusinessRegister set EmailVerification=1 where Email='" + @Param.ToString() + "' and  deleted=0";
                SqlCommand cmd = new SqlCommand(sql, connMenu);
                cmd.ExecuteNonQuery();
                BusinessTier.DisposeConnection(connMenu);
                Response.Redirect("login.aspx?param=1", false);
            //}
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["CustomerID"].Value.ToString(), "EmailVerification", "Page_Load", ex.ToString(), "Audit");
            Response.Redirect("index.aspx",false);
        }
        finally
        {
            BusinessTier.DisposeConnection(connMenu);
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