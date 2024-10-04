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

public partial class Products : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();

    public int Loadpage = 0;

    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

    protected void Page_PreInit(object sender, EventArgs e)
    {
        string @Param = string.Empty, @Param1 = string.Empty;
        @Param = Request.QueryString.Get("Param").ToString();
        @Param1 = Request.QueryString.Get("Param1").ToString();
        string strUA = Request.UserAgent.Trim().ToLower();
        bool isMobile = false;
        if (strUA.Contains("ipod") || strUA.Contains("iphone"))
            isMobile = true;

        if (strUA.Contains("android"))
            isMobile = true;

        if (strUA.Contains("opera mobi"))
            isMobile = true;

        if (strUA.Contains("windows phone os") && strUA.Contains("iemobile"))
            isMobile = true;

        if (strUA.Contains("palm"))
            isMobile = true;

        bool MobileDevice = Request.Browser.IsMobileDevice;
        if (isMobile == true && MobileDevice == true)
        {
            string url = string.Empty;

            url = "http:\\m.easybuybye.com/category-view/" + @Param1 + "?Param=" + @Param ;

            Response.Write("<script>window.open('" + url + "','_self');</script>");
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        SqlConnection con = BusinessTier.getConnection();
        try
        {
            string @Param = string.Empty, @Param1 = string.Empty, @Param2 = string.Empty;
            @Param = Request.QueryString.Get("Param").ToString();
            @Param1 = Request.QueryString.Get("Param1").ToString();
            @Param2 = "0";
            con.Open();

            if (@Param != "22")// && @Param != "46")  
            {
                cboSize.Visible = false;
                lblSize.Visible = false;
            }
            string sql = string.Empty;
            sql = "SELECT TagProductID from ADMIN_PRODUCT_TAG_TBL where TagCategoryID=" + @Param.ToString().Trim() + " and deleted=0";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                @Param2 = reader["TagProductID"].ToString();
            }
            BusinessTier.DisposeReader(reader);

            SqlDataReader rdRecentitems = BusinessTier.getallProductsList(con, @Param, cboBasicCategories.SelectedItem.Text, @Param2);
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);

            if (dtRecentitems.Rows.Count != 0)
            {
                Loadpage = 1;
            }           
        }
        catch (Exception ex)
        {
            Response.Redirect("index.aspx", false);
        }
        finally
        {
            con.Close();
        }
    }

    protected void cboSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboBasicCategories.SelectedIndex = 0;
        string @Param = string.Empty, @Param1 = string.Empty;
        @Param = Request.QueryString.Get("Param").ToString();
        @Param1 = Request.QueryString.Get("Param1").ToString();
        SqlConnection con = BusinessTier.getConnection();
        con.Open();
        SqlDataReader rdRecentitems;
        dtRecentitems.Rows.Clear();

        if (cboSize.SelectedItem.Text.ToString() == "Default")
        {
            rdRecentitems = BusinessTier.getallProductsList(con, @Param, cboBasicCategories.SelectedItem.Text,"");
        }
        else
        {
            rdRecentitems = BusinessTier.getcboSizeList(con, @Param, cboSize.SelectedItem.Text);
        }
        dtRecentitems.Load(rdRecentitems);
        BusinessTier.DisposeReader(rdRecentitems);
        BusinessTier.DisposeConnection(con);
    }

    protected void cboBasicCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        cboSize.SelectedIndex = 0;
        string @Param = string.Empty, @Param1 = string.Empty;
        @Param = Request.QueryString.Get("Param").ToString();
        @Param1 = Request.QueryString.Get("Param1").ToString();
        SqlConnection con = BusinessTier.getConnection();
        con.Open();
        SqlDataReader rdRecentitems1;
        dtRecentitems.Rows.Clear();

        string sql = string.Empty;
        sql = "SELECT TagProductID from ADMIN_PRODUCT_TAG_TBL where TagCategoryID=" + @Param.ToString().Trim() + " and deleted=0";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            @Param1 = reader["TagProductID"].ToString();
        }
        BusinessTier.DisposeReader(reader);


        rdRecentitems1 = BusinessTier.getallProductsList(con, @Param, cboBasicCategories.SelectedItem.Text, @Param1);
        dtRecentitems.Load(rdRecentitems1);
        BusinessTier.DisposeReader(rdRecentitems1);
        BusinessTier.DisposeConnection(con);
    }   
}