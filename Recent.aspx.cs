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

public partial class Recent : System.Web.UI.Page
{
    public DataTable dtRecentitems = new DataTable();  

    protected void Page_Load(object sender, EventArgs e)
    {
        using(SqlConnection connMenu = BusinessTier.getConnection())
        {
            string condition = string.Empty;
            //if (string.IsNullOrEmpty(cboSortby.SelectedValue.ToString()))
            //{
                condition = "Latest";
            ////}
            ////else
            ////{
            ////    condition = cboSortby.SelectedValue.ToString();
            ////}
            connMenu.Open();
            SqlDataReader rdRecentitems = BusinessTier.getRecentitems(connMenu,condition.ToString());
            dtRecentitems.Load(rdRecentitems);
            BusinessTier.DisposeReader(rdRecentitems);
        }
    }

}