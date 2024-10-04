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

public partial class AboutUs : System.Web.UI.Page
{
  
    int expire = Convert.ToInt32(WebConfigurationManager.AppSettings["Expire"].ToString());

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
            Response.Write("<script>window.open('http://m.easybuybye.com','_self');</script>");
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
       
       
    }
   
   
}