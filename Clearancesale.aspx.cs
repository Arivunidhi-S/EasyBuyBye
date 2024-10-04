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

public partial class Clearancesale : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();
    protected void Page_PreInit(object sender, EventArgs e)
    {
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
            Response.Write("<script>window.open('https://www.m.easybuybye.com/Clearancesale','_self');</script>");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {        
        SqlConnection connMenu = BusinessTier.getConnection();
        try
        {
            string condition = string.Empty;
            if (string.IsNullOrEmpty(cboSortby.SelectedValue.ToString()))
            {
                condition = "Latest";
            }
            else
            {
                condition = cboSortby.SelectedValue.ToString();
            }

            connMenu.Open();
            string param = "3";
            //SqlDataReader rdRecentitems = BusinessTier.getRM5(connMenu, condition.ToString(),"55");
            string sql = string.Empty;
            if (condition == "Latest" || condition == "First")
            {
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id from Vw_Products where MasterDel=0 and Approve=1 and OfferID='" + param.ToString() + "' order by priority asc";
            }
            else if (condition == "Category")
            {
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and OfferID='" + param.ToString() + "' order by Categoryid asc";
            }
            else if (condition == "asc")
            {
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and OfferID='" + param.ToString() + "' order by DiscountPrice asc";
            }
            else if (condition == "desc")
            {
                sql = "select Brand,Model,SellingPrice,imagepath,productid,DiscountPrice,Discount,Brand + ' ' + Model as BrMod,CASE WHEN LEN(Brand + ' ' + Model)< 50 then left((Brand + ' ' + Model),50) else left((Brand + ' ' + Model),50)+'...' end as ShortBrMod,TotalStock,Category,id ,Categoryid from Vw_Products where MasterDel=0 and Approve=1 and OfferID='" + param.ToString() + "' order by DiscountPrice desc";
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connMenu);
           // DataTable g_datatable = new DataTable();
            sqlDataAdapter.Fill(dtRecentitems);
            //dtRecentitems.Load(g_datatable);
            BusinessTier.DisposeAdapter(sqlDataAdapter);
            BusinessTier.DisposeConnection(connMenu);

            //SqlCommand cmd = new SqlCommand(sql, connMenu);
            //SqlDataReader reader = cmd.ExecuteReader();

            ////dtRecentitems.Load(rdRecentitems);
            ////BusinessTier.DisposeReader(rdRecentitems);

            //connMenu.Close();
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