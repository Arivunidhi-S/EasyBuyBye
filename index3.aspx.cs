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
using System.IO;

public partial class index3 : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    public DataTable dtRecentitems1 = new DataTable();

    public DataTable dtRecentitems2 = new DataTable();

    public DataTable dtRecentitems3 = new DataTable();

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = BusinessTier.getConnection();
        //BusinessTier.GetIPLocation(HttpContext.Current.Request.UserHostAddress);       
        try
        {
            con.Open();

            SqlDataReader rdRecentitems = BusinessTier.getFeatureitems(con);
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);

            SqlDataReader rdRecentitems1 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion2"].ToString());
            dtRecentitems1.Load(rdRecentitems1);
            BusinessTier.DisposeReader(rdRecentitems1);

            SqlDataReader rdRecentitems2 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion1"].ToString());//BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexWomenFashion3"].ToString());
            dtRecentitems2.Load(rdRecentitems2);
            BusinessTier.DisposeReader(rdRecentitems2);

            SqlDataReader rdRecentitems3 = BusinessTier.getProductitems(con, WebConfigurationManager.AppSettings["IndexMenFashion1"].ToString());
            dtRecentitems3.Load(rdRecentitems3);
            BusinessTier.DisposeReader(rdRecentitems3);
            //if (!IsPostBack)
            //{
            //    if (Request.Cookies["CustomerID"].Value.ToString() == "0")
            //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "pgload();", true);
            //}
            
        }
        catch (Exception ex)
        {
            con.Close();
            Response.Redirect("index.aspx", false);
        }
        finally
        {
            con.Close();
        }
    }
    
}