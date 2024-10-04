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

public partial class AllProducts : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();
    public int Loadpage = 0;
    public string @Basic = string.Empty, @Sub = string.Empty;

    protected void Page_Init(object sender, EventArgs e)
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        try
        {

            string sql = string.Empty;
            @Basic = Request.QueryString.Get("Basic").ToString();
            @Sub = Request.QueryString.Get("Sub").ToString();

            string condition = string.Empty;
            if (string.IsNullOrEmpty(cboSortby.SelectedValue.ToString()))
            {
                condition = "productid desc";
            }
            else
            {
                condition = cboSortby.SelectedValue.ToString();
            }

            connMenu.Open();


            if (@Basic != "0")
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,BasicCategory,BasicCategoryID from Vw_Products where MasterDel=0 and BasicCategoryID='" + @Basic.ToString() + "' and  Approve=1 order by " + condition.ToString() + "";
            else if (@Sub != "0")
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,SubCategory,SubCategoryID,BasicCategory,BasicCategoryID from Vw_Products where MasterDel=0 and Approve=1 and SubCategoryID='" + @Sub.ToString() + "'  order by " + condition.ToString() + "";


            SqlCommand cmd = new SqlCommand(sql, connMenu);
            SqlDataReader rdRecentitems = cmd.ExecuteReader();
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);
            if (dtRecentitems.Rows.Count != 0)
            {
                Loadpage = 1;
            }
            connMenu.Close();
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

    protected void Page_PreInit(object sender, EventArgs e)
    {
        @Basic = Request.QueryString.Get("Basic").ToString();
        @Sub = Request.QueryString.Get("Sub").ToString();

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
               if (@Basic != "0")
                   url = "http:\\m.easybuybye.com/category/" + @Basic;
               else
                   url = "http:\\m.easybuybye.com/category-view/" + @Sub;

            Response.Write("<script>window.open('" + url + "','_self');</script>");
        }
    }

    protected void cboSortby_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection connMenu = BusinessTier.getConnection();
        try
        {

            string sql = string.Empty;
            @Basic = Request.QueryString.Get("Basic").ToString();
            @Sub = Request.QueryString.Get("Sub").ToString();

            string condition = string.Empty;
            if (string.IsNullOrEmpty(cboSortby.SelectedValue.ToString()))
            {
                condition = "productid desc";
            }
            else
            {
                condition = cboSortby.SelectedValue.ToString();
            }

            connMenu.Open();


            if (@Basic != "0")
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,BasicCategory,BasicCategoryID from Vw_Products where MasterDel=0 and BasicCategoryID='" + @Basic.ToString() + "' and  Approve=1 order by " + condition.ToString() + "";
            else if (@Sub != "0")
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id,SubCategory,SubCategoryID,BasicCategory,BasicCategoryID from Vw_Products where MasterDel=0 and Approve=1 and SubCategoryID='" + @Sub.ToString() + "'  order by " + condition.ToString() + "";

            
            SqlCommand cmd = new SqlCommand(sql, connMenu);
            SqlDataReader rdRecentitems = cmd.ExecuteReader();
            dtRecentitems.Clear();
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);
            if (dtRecentitems.Rows.Count != 0)
            {
                Loadpage = 1;
            }
            connMenu.Close();
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