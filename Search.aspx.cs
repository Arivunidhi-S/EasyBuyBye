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
using System.Web.Services;

public partial class Search : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    //public DataTable dtCategories = new DataTable();

    //public DataTable dtMenuItems = new DataTable();

    //public DataTable dtSubMenuItems = new DataTable();

    //int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    public void Page_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridSearch();
        }
    }

    public void btnSearch_OnClick(object sender, EventArgs e)
    {
        GridSearch();
    }

    public void GridSearch()
    {
        lblResult.Text = "";
        SqlConnection connMenu = BusinessTier.getConnection();
        try
        {
            string @Param = string.Empty;
            if (string.IsNullOrEmpty(txtSearch.Text.ToString()))
            {
                @Param = Request.QueryString.Get("Param").ToString();
            }
            else
            {
                @Param = txtSearch.Text.ToString();
            }
            connMenu.Open();

            if (string.IsNullOrEmpty(@Param.ToString()))
            {
                BusinessTier.DisposeConnection(connMenu);
                return;
            }
            Regex charregex = new Regex(@"[^a-zA-Z0-9\s.]");
            if ((charregex.IsMatch(@Param.ToString().Trim())))
            {
                return;
            }
            SqlDataReader readerMenu = BusinessTier.getSearchList(connMenu, @Param);
            dtRecentitems.Rows.Clear();
            dtRecentitems.Load(readerMenu);
            if (dtRecentitems.Rows.Count != 0)
            {
                lblResult.Text = "Search result for <b style='color:orange;'>'" + @Param + "'</b>";
            }
            else
            {
                dtRecentitems.Rows.Clear();
                lblResult.Text = "No products found.<br> Try different or more general keywords";
            }
            BusinessTier.DisposeReader(readerMenu);

            BusinessTier.DisposeConnection(connMenu);
        }
        catch (Exception ex)
        {

            Response.Redirect("index.aspx", false);
        }
        finally
        {
            connMenu.Close();
        }
    }
   
  
}