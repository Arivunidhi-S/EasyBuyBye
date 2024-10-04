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

public partial class RM5 : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();  

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
            SqlDataReader rdRecentitems = BusinessTier.getRM5(connMenu, condition.ToString(),"55");
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);

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